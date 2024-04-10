using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dropdown : MonoBehaviour
{
    public int runType;
    public GameObject sign1;
    public GameObject sign2;
    public void HandleInputData(int value)
    {
        if (value == 0)
        {
            runType = 0;
            sign1.SetActive(true);
            sign2.SetActive(false);
        }
        if (value == 1)
        {
            runType = 1;
            sign1.SetActive(false);
            sign2.SetActive(true);
        }
    }
}
