using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSettings : MonoBehaviour
{
    public GameObject cameraScript;
    public Slider sensitivitySlider;
    public TMP_Dropdown runTypeDropDown;
    public void Start()
    {
        if (PlayerPrefs.HasKey ("sensitivity"))
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
            runTypeDropDown.value = PlayerPrefs.GetInt("runType");
            print("load");
        }
        else
        {
            print("NoSave");
        }
    }
}
