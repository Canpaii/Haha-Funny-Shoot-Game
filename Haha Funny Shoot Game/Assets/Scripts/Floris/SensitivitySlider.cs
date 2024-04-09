using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    public GameObject cameraScript;
    public void SliderMovement(float f)
    {
        cameraScript.GetComponent<CameraRotation>().sensitivityX = f;
        cameraScript.GetComponent<CameraRotation>().sensitivityY = f;
    }
}
