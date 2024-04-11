using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public GameObject escMenu;
    public GameObject timer;
    public GameObject highscoreTimer;
    public GameObject disCamera;
    public GameObject returnToGame;
    public GameObject settings;
    public GameObject quitToMainMenu;
    public bool checkToLeave;
    public GameObject player;
    public bool checkForMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (checkToLeave == true)
            {
                if (checkForMenu == false)
                {
                    escMenu.SetActive(true);
                    returnToGame.SetActive(true);
                    settings.SetActive(true);
                    quitToMainMenu.SetActive(true);
                    timer.SetActive(false);
                    highscoreTimer.SetActive(false);
                    Time.timeScale = 0;
                    disCamera.GetComponent<CameraRotation>().enabled = false;
                    player.GetComponent<CursorVisible>().cursorVis = true;
                    checkForMenu = true;
                }
                else
                {
                    escMenu.SetActive(false);
                    returnToGame.SetActive(false);
                    settings.SetActive(false);
                    quitToMainMenu.SetActive(false);
                    timer.SetActive(true);
                    highscoreTimer.SetActive(true);
                    Time.timeScale = 1;
                    disCamera.GetComponent<CameraRotation>().enabled = true;
                    player.GetComponent<CursorVisible>().cursorVis = false;
                    checkForMenu = false;
                }
            }
        }
    }
}
