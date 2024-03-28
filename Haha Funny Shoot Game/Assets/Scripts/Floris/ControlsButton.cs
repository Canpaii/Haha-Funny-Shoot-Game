using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : MonoBehaviour
{
    public GameObject controls;
    public GameObject sounds;
    public GameObject credits;
    public GameObject cancel;
    public GameObject sensitivity;
    public GameObject runtype;
    public GameObject cancel1;
    public void ButtonPress()
    {
        controls.SetActive(false);
        sounds.SetActive(false);
        credits.SetActive(false);
        cancel.SetActive(false);
        sensitivity.SetActive(true);
        runtype.SetActive(true);
        cancel1.SetActive(true);
    }
}
