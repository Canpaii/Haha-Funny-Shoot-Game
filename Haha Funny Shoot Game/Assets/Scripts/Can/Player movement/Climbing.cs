using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    [Header("References")]
    public Transform ladderCheck;
    public Rigidbody rb;
    public BasicMovement bm;
    public LayerMask ladder;

    [Header("Climbing")]
    public float climbSpeed;
    private bool climbing;

    [Header("WallCheck")]
    public float detectionLength;

    public int ladderLayerIndex;
    private RaycastHit frontWallHit;
    private bool wall;

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
        if (wall && Input.GetKey(KeyCode.W))
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
         wall = Physics.Raycast(ladderCheck.position, ladderCheck.forward, out frontWallHit, detectionLength, ladder);
         Debug.DrawRay(ladderCheck.position, ladderCheck.forward,Color.red ,detectionLength);
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
