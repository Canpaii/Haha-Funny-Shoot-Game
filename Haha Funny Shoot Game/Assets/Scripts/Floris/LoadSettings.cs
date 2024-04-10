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
        sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
        runTypeDropDown.value = PlayerPrefs.GetInt("runType");
        print("load");
    }
}
