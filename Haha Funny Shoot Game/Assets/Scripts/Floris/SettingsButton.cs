using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject start;
    public GameObject settings;
    public GameObject quit;
    public GameObject controls;
    public GameObject credits;
    public GameObject cancel;
    public GameObject logo;
 
    public void ButtonPress()
    {
        start.SetActive(false);
        settings.SetActive(false);
        quit.SetActive(false);
        logo.SetActive(false);
        controls.SetActive(true);
        credits.SetActive(true);
        cancel.SetActive(true);
    }
}
