using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReturnButton1 : MonoBehaviour
{
    public GameObject controls;
    public GameObject credits;
    public GameObject cancel;
    public GameObject sensitivity;
    public GameObject runtype;
    public GameObject cancel1;
    public void ButtonPress()
    {
        controls.SetActive(true);
        credits.SetActive(true);
        cancel.SetActive(true);
        sensitivity.SetActive(false);
        runtype.SetActive(false);
        cancel1.SetActive(false);
    }
}
