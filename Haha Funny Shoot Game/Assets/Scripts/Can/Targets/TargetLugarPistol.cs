using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLugarPistol : MonoBehaviour
{
    public bool hit;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == ("Bullet Lugar"))
        {
            hit = true;
        }
    }
}
