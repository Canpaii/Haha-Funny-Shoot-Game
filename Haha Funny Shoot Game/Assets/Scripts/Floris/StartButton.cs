using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class StartButton : MonoBehaviour
{
    public GameObject start;
    public GameObject settings;
    public GameObject quit;

    public void ButtonPress()
    {
        start.SetActive(false);
        settings.SetActive(false);
        quit.SetActive(false);
    }

}
