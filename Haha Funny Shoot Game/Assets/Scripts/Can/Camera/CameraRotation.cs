using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;

    private float rotationX;

    public float minXRotation;
    public float maxXRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minXRotation, maxXRotation);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
