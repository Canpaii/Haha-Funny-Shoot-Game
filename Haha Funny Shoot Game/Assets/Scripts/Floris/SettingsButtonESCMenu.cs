using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonESCMenu : MonoBehaviour
{
    public GameObject backGround;
    public GameObject returnToGame;
    public GameObject settings;
    public GameObject quitToMainMenu;
    public GameObject sensitivitySlider;
    public GameObject runType;
    public GameObject returnToESCMenu;
    public GameObject allowToLeave;
    public void ButtonPress()
    {
        backGround.SetActive(true);
        sensitivitySlider.SetActive(true);
        runType.SetActive(true);
        returnToESCMenu.SetActive(true);
        returnToGame.SetActive(false);
        settings.SetActive(false);
        quitToMainMenu.SetActive(false);
        allowToLeave.GetComponent<EscapeMenu>().checkToLeave = false;
    }
}
