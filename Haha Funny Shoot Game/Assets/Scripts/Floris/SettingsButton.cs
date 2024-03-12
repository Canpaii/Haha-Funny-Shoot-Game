using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject start;
    public GameObject settings;
    public GameObject quit;
    public GameObject controls;
    public GameObject sounds;
    public GameObject credits;
    public GameObject cancel;
 
    public void ButtonPress()
    {
        start.SetActive(false);
        settings.SetActive(false);
        quit.SetActive(false);
        controls.SetActive(true);
        sounds.SetActive(true);
        credits.SetActive(true);
        cancel.SetActive(true);
    }
}
