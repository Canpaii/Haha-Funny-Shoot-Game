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

    public GameObject backGround;

    public GameObject disCamera;

    public GameObject player;

    public GameObject allowToLeave;

    public GameObject crosshair;
    // Update is called once per frame
    public void Hello()
    {

        disCamera.GetComponent<CameraRotation>().enabled = false;
        player.GetComponent<BasicMovement>().enabled = false;
        player.GetComponent<CursorVisible>().cursorVis = true;

        yes1.SetActive (true);
        no1.SetActive (true);
        hello.SetActive (true);
        backGround.SetActive (true);
        crosshair.SetActive(false);
        allowToLeave.GetComponent<EscapeMenu>().checkToLeave = false;
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
        veelSucces.SetActive(false);
        backGround.SetActive(false);

        disCamera.GetComponent<CameraRotation>().enabled = true;
        player.GetComponent<BasicMovement>().enabled = true;
        player.GetComponent<CursorVisible>().cursorVis = false;
        allowToLeave.GetComponent<EscapeMenu>().checkToLeave = true;
    }
}
