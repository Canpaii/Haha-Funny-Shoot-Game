using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSettings : MonoBehaviour
{
    public GameObject cameraScript;
    public Slider sensitivitySlider;
    public void Start()
    {
        sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
        print("load");
    }
}
