using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolderRotation : MonoBehaviour
{
    public Transform cameraHolder;

    public void Update()
    {
        transform.rotation = cameraHolder.rotation;
    }
}
