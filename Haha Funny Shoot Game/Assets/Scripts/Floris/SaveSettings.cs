using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    public GameObject cameraScript;
    public float f;
    public void ButtonPress()
    {
        cameraScript.GetComponent<CameraRotation>().sensitivityX = f;
        cameraScript.GetComponent<CameraRotation>().sensitivityY = f;
        PlayerPrefs.SetFloat("sensitivity", f);
        PlayerPrefs.Save();
    }
}
