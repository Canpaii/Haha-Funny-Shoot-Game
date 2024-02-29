using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRaycast : MonoBehaviour
{
    public float rayLength;
    public GameObject talk;
    public bool presF;

    // Update is called once per frame
    public void Update()
    {
        RaycastHit hit;


        if(Physics.Raycast(transform.position,transform.forward, out hit, rayLength) && hit.transform.tag == "Npc")
        {
            if(presF == true)
            {
                talk.SetActive(false);
            }
            else
            {
                talk.SetActive(true);
            }

            // show talk button ui    F to talk
            if (Input.GetKeyDown(KeyCode.F))
            {
                presF = true;
                GetComponent<FToTalk>().Hello();
            }
        }
        else 
        {
            talk.SetActive (false);
        }
    }
}
