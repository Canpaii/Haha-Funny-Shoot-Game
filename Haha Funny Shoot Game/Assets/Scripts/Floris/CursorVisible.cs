using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursorVisible : MonoBehaviour
{
    public bool cursorVis;
    void Update()
    {
        if (cursorVis == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
