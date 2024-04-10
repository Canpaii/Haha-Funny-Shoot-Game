using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FToTalk : MonoBehaviour
{

    public GameObject yes1;
    public GameObject ok1;
    public GameObject no1;
    public GameObject ok2;

    public GameObject hello;
    public GameObject uitleg;
    public GameObject veelSucces;

    public GameObject disCamera;


    // Update is called once per frame
    public void Hello()
    {

        disCamera.GetComponent<CameraRotation>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
         
        yes1.SetActive (true);
        no1.SetActive (true);
        hello.SetActive (true);
    }

    public void Explain()
    {
        
        yes1 .SetActive (false);
        no1 .SetActive (false);
        hello .SetActive (false);

        uitleg .SetActive (true);
        ok1.SetActive (true);
    }

    public void Bye()
    {
        yes1.SetActive(false);
        no1.SetActive(false);
        hello.SetActive(false);

        uitleg.SetActive (false);
        ok1.SetActive (false);

        ok2.SetActive (true);
        veelSucces.SetActive (true);
    }

    public void ReallyBye()
    {
        ok2.SetActive(false);
        veelSucces.SetActive (false);

        Cursor.visible = false;

        disCamera.GetComponent<CameraRotation>().enabled = true;
        print("why");
    }
}
