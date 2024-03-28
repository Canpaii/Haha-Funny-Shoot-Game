using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsButton : MonoBehaviour
{
    public GameObject controls;
    public GameObject sounds;
    public GameObject credits;
    public GameObject cancel;
    public GameObject mainVolume;
    public GameObject gunVolume;
    public GameObject cancelSoundMenu;
    public void ButtonPress()
    {
        controls.SetActive(false);
        sounds.SetActive(false);
        credits.SetActive(false);
        cancel.SetActive(false);
        mainVolume.SetActive(true);
        gunVolume.SetActive(true);
        cancelSoundMenu.SetActive(true);
    }
}
