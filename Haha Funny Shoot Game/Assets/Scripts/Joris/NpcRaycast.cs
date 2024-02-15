using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRaycast : MonoBehaviour
{
    public float rayLength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward, out hit, rayLength) && hit.transform.tag == "Npc")
        {
            // show talk button ui
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("wee");
            }
        }
    }
}
