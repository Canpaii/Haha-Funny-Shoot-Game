using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveSettings : MonoBehaviour
{
    public GameObject cameraScript;
    public Slider sensitivitySlider;
    public TMP_Dropdown runTypeDropDown;
    public void ButtonPress()
    {
        PlayerPrefs.SetFloat("sensitivity", sensitivitySlider.value);
        PlayerPrefs.SetInt("runType", runTypeDropDown.value);
        PlayerPrefs.Save();
        print("save");
    }
}
