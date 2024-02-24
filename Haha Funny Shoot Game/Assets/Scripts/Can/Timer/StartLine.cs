using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour
{
    public GameObject timer;
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == ("Player"))
        {
            timer.GetComponent<Timer>().isRunning = true;
            timer.GetComponent<Timer>().startTimerFlag = true;
        }
    }
}
