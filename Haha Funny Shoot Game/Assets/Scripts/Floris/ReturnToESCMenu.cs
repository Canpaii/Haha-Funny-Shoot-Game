using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToESCMenu : MonoBehaviour
{
    public GameObject backGround;
    public GameObject returnToGame;
    public GameObject settings;
    public GameObject quitToMainMenu;
    public GameObject sensitivitySlider;
    public GameObject runType;
    public GameObject returnToESCMenu;
    public bool allowToLeave;
    public void ButtonPress()
    {
        backGround.SetActive(false);
        sensitivitySlider.SetActive(false);
        runType.SetActive(false);
        returnToESCMenu.SetActive(false);
        returnToGame.SetActive(true);
        settings.SetActive(true);
        quitToMainMenu.SetActive(true);
        allowToLeave = true;
    }
}
