using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToGame : MonoBehaviour
{
    public GameObject escMenu;
    public GameObject timer;
    public GameObject highscoreTimer;
    public GameObject disCamera;
    public GameObject escapeMenu;
    public GameObject returnToGame;
    public GameObject settings;
    public GameObject quitToMainMenu;
    public GameObject player;
    public void ButtonPress()
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
        escapeMenu.GetComponent<EscapeMenu>().checkForMenu = false;
    }
}
