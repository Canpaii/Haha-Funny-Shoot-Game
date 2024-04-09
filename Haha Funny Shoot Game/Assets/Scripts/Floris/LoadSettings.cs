using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSettings : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.GetFloat("sensitivity");

    }
}
