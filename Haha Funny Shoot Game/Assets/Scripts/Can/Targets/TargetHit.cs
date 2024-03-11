using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public bool luger;
    public bool garand;
    public bool hit;
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Bullet M1Garand" && garand)
        {
            hit = true;
        }
        if(other.transform.tag == "Bullet Lugar" && luger)
        {
            hit = true;
        }
    }
}
