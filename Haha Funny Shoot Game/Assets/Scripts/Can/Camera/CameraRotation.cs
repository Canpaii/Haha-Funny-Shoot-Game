using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
public class CameraRotation : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;

    private float rotationX;
    private float rotationY;

    public float minXRotation;
    public float maxXRotation;

    public Slider sensitivitySlider;

    public GameObject orientation;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        sensitivitySlider.value = sensitivityX;
        sensitivitySlider.value = sensitivityY;
        
        float mouseX = Input.GetAxis("Mouse X") * sensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivityY;

        rotationX -= mouseY;
        rotationY += mouseX;
        rotationX = Mathf.Clamp(rotationX, minXRotation, maxXRotation);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
