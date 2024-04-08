using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSettings : MonoBehaviour
{
    public GameObject cameraScript;
    public void ButtonPress(float f)
    {
        cameraScript.GetComponent<CameraRotation>().sensitivityX = f;
        cameraScript.GetComponent<CameraRotation>().sensitivityY = f;
        PlayerPrefs.SetFloat("sensitivity", f);
        PlayerPrefs.Save();
    }
    private void Start()
    {
        float sensitivity = PlayerPrefs.GetFloat("sensitivity");
    }
}
