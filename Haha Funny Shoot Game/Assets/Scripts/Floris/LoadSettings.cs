using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSettings : MonoBehaviour
{
    [SerializeField]

    public GameObject cameraScript;
    float f;
    void Start()
    {
        f = PlayerPrefs.GetFloat("sensitivity");
        cameraScript.GetComponent<CameraRotation>().sensitivityX = f;
        cameraScript.GetComponent<CameraRotation>().sensitivityY = f;
    }
}
