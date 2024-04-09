using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escMenu;
    public GameObject timer;
    public GameObject highscoreTimer;
    public GameObject disCamera;
    public bool checkForMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (checkForMenu == false)
            {
                escMenu.SetActive(true);
                timer.SetActive(false);
                highscoreTimer.SetActive(false);
                Time.timeScale = 0;
                checkForMenu = true;
                disCamera.GetComponent<CameraRotation>().enabled = false;
            }
            else
            {
                escMenu.SetActive(false);
                timer.SetActive(true);
                highscoreTimer.SetActive(true);
                Time.timeScale = 1;
                checkForMenu = false;
                disCamera.GetComponent<CameraRotation>().enabled = true;
            }
        }
    }
}
