using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetM1Garand : MonoBehaviour
{
    public bool hit;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == ("Bullet M1Garand"))
        {
            hit = true;
        }
    }
}
