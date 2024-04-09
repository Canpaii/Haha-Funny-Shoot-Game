using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    public GameObject cameraScript;
    public float sensitivityValue;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetFloat("sensitivity", sensitivityValue);
            PlayerPrefs.Save();
            print("save");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            sensitivityValue = PlayerPrefs.GetFloat("sensitivity");
            sensitivityValue = PlayerPrefs.GetFloat("sensitivity");
            print("load");
        }
    }
}
