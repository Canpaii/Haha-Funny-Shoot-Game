using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveSettings : MonoBehaviour
{
    public GameObject cameraScript;
    public float sensitivityValue;
    public Slider sensitivitySlider;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetFloat("sensitivity", sensitivitySlider.value);
            PlayerPrefs.Save();
            print("save");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
            sensitivitySlider.value = PlayerPrefs.GetFloat("sensitivity");
            print("load");
        }
    }
}
