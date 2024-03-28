using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButton2 : MonoBehaviour
{
    public GameObject controls;
    public GameObject sounds;
    public GameObject credits;
    public GameObject cancel;
    public GameObject mainVolume;
    public GameObject gunVolume;
    public GameObject cancel2;
    public void ButtonPress()
    {
        controls.SetActive(true);
        sounds.SetActive(true);
        credits.SetActive(true);
        cancel.SetActive(true);
        mainVolume.SetActive(false);
        gunVolume.SetActive(false);
        cancel2.SetActive(false);
    }
}
