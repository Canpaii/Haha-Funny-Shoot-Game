using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Rigidbody rb;
    public BasicMovement bm;
    public LayerMask ladder;

    [Header("Climbing")]
    public float climbSpeed;
    private bool climbing;

    [Header("WallCheck")]
    public float detectionLength;
    public float sphereCastRadius;
    public float maxWallLookAngle;
    private float wallLookAngle;

    private RaycastHit frontWallHit;
    private bool wallFront;

    private void Update()
    {
        WallCheck();
        StateMachine();

        if (climbing)
        {
            ClimbingMovement();
        }
    }
    private void StateMachine()
    {
        if (wallFront && Input.GetKey(KeyCode.W) && wallLookAngle < maxWallLookAngle)
        {
             StartClimbing();
        }
        else
        {
            if (climbing)
            {
                StopClimbing();
            }
        }
    }
    private void WallCheck()
    {
        wallFront = Physics.SphereCast(transform.position, sphereCastRadius, orientation.forward, out frontWallHit, detectionLength, ladder);
        wallLookAngle = Vector3.Angle(orientation.forward, -frontWallHit.normal);
    }
    private void StartClimbing()
    {
        climbing = true;
        bm.climbing = true; 
    }
    private void ClimbingMovement()
    {
        rb.velocity = new Vector3(rb.velocity.x, climbSpeed, rb.velocity.z);

        //sound effect
    }
    private void StopClimbing()
    {
        climbing = false;
        bm.climbing = false;
    }
}
