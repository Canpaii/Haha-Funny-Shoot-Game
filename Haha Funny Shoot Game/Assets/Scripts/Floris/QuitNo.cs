using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitNo : MonoBehaviour
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
        start.SetActive(true);
        settings.SetActive(true);
        quit.SetActive(true);
        logo.SetActive(true);
        highscore.SetActive(true);
        quitNo.SetActive(false);
        quitYes.SetActive(false);
        areYouSure.SetActive(false);
    }
}
