using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveSettings : MonoBehaviour
{
    public GameObject cameraScript;
    public Slider sensitivitySlider;
    public void ButtonPress()
    {
            PlayerPrefs.SetFloat("sensitivity", sensitivitySlider.value);
            PlayerPrefs.Save();
            print("save");
    }
}
