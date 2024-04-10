using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dropdown : MonoBehaviour
{
    public int runType;
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            runType = 0;
        }
        if (val == 1)
        {
            runType = 1;
        }
    }
}
