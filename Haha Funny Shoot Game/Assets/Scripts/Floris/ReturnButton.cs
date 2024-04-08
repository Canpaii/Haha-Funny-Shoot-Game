using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton : MonoBehaviour
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
        start.SetActive(true);
        settings.SetActive(true);
        quit.SetActive(true);
        logo.SetActive(true);
        controls.SetActive(false);
        credits.SetActive(false);
        cancel.SetActive(false);
    }
}
