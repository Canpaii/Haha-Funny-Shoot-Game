using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public GameObject start;
    public GameObject settings;
    public GameObject quit;
    public GameObject logo;
    public GameObject quitNo;
    public GameObject quitYes;
    public GameObject highscore;
    public GameObject areYouSure;
    public void ButtonPress()
    {
        start.SetActive(false);
        settings.SetActive(false);
        quit.SetActive(false);
        logo.SetActive(false);
        highscore.SetActive(false);
        quitNo.SetActive(true);
        quitYes.SetActive(true);
        areYouSure.SetActive(true);
    }
}
