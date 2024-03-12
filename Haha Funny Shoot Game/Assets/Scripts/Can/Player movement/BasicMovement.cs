using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class BasicMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float walkspeed;
    public float sprintSpeed;
    public bool sprinting;
    public float climbSpeed;
    public float gravity;
    public float groundDrag;

    float hor;
    float vert;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    public bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    public float crouchHeight;
    private float startYScale;
    public bool crouching;

    [Header("Reference")]
    public Transform orientation;
    Rigidbody rb;
    private Vector3 moveDirection;
    public GunScript zoomM1Garand;
    public GunScript zoomLugerPistol;

    [Header("Ground Check")]
    public float playerHeight;
    public float rayLength;
    public LayerMask whatIsGround;
    public bool grounded;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    public bool exitingSlope;
    private RaycastHit slopeHit;

    [Header("Climbing")]
    public bool climbing;

    [Header("State")]
    // Define state player is in
    public MovementState state;
    public enum MovementState 
    {
        walking,
        crouching,
        sprinting,
        climbing,
        airSprint,
        airCrouch,
        air,
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        startYScale = transform.localScale.y;
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        grounded = Physics.Raycast(ray, rayLength * 0.5f + 0.2f, whatIsGround);

        Debug.DrawRay(ray.origin, ray.direction * (rayLength * 0.5f + 0.2f), grounded ? Color.green : Color.red);

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        MyInput();
        SpeedControl();
        StateHandler();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MyInput()
    {
        hor = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(KeyCode.Space) && readyToJump && grounded && !crouching)
        {
            readyToJump = false;
            Jump();
            Invoke("ResetJump", jumpCooldown);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && grounded)
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            crouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            crouching = false;
        }

        if (rb.velocity == Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            sprinting = false;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && !zoomM1Garand.zoomed && !zoomLugerPistol.zoomed)
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }
    }   
    private void StateHandler()
    {
        if (climbing)
        {
            state = MovementState.climbing;
            speed = climbSpeed;
        }
        if (crouching && grounded) // crouching
        {
            state = MovementState.crouching;
            speed = crouchSpeed;
            rayLength = crouchHeight;
        }
        else if(grounded && sprinting) // sprinting 
        {
            state = MovementState.sprinting;
            speed = sprintSpeed;
            rayLength = playerHeight;
        }
        else if (grounded) //walking 
        {
            state = MovementState.walking;
            speed = walkspeed;
            rayLength = playerHeight;
        }
        else if (crouching && !grounded) //Crouching in air
        {
            state = MovementState.airCrouch;
            rayLength = crouchHeight;
            speed = crouchSpeed;
            sprinting = false;
            rb.AddForce(Vector3.down * gravity, ForceMode.Force);
        }
        else if (!grounded && sprinting) //Sprinting in air
        {
            state = MovementState.airSprint;
            rayLength = playerHeight;
            rb.AddForce(Vector3.down * gravity, ForceMode.Force);
        }
        else //air 
        {
            state = MovementState.air;
            rayLength = playerHeight;
            rb.AddForce(Vector3.down * gravity, ForceMode.Force);
        }
    }
    void MovePlayer()
    {
        moveDirection = orientation.transform.forward * vert + orientation.transform.right * hor;

        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * speed * 20f, ForceMode.Force);
            if(rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        } 
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * speed * 10, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * speed * 5 * airMultiplier, ForceMode.Force); 
        }

        rb.useGravity = !OnSlope();
    }
    private void SpeedControl()
    {
        if (OnSlope() && !exitingSlope)
        {
            if(rb.velocity.magnitude > speed)
            {
                rb.velocity = rb.velocity.normalized * speed;
            }
        }
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            if (flatVel.magnitude > speed)
            {
                Vector3 limitedVel = flatVel.normalized * speed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
    }
    private void Jump()
    {
        exitingSlope = true;
        rb.velocity = new Vector3(rb.velocity.x , 0 , rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
        exitingSlope = false;
    }
    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, rayLength * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0; 
        }

        return false;
    }
    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
}
