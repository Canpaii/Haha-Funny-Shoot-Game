using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public bool luger;
    public bool garand;
    public bool hit;
    public AudioSource collisionhit;
    public AudioSource hitSfx;
    private void OnCollisionEnter(Collision other)
    {
        collisionhit.Play();
        if(other.transform.tag == "Bullet M1Garand" && garand)
        {
            hit = true;
            hitSfx.Play();
        }
        if(other.transform.tag == "Bullet Lugar" && luger)
        {
            hit = true;
            hitSfx.Play();
        }
    }
}
