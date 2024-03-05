using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPenalty : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    private Timer timer;
    public void CalculatePenalty()
    {
        foreach (GameObject target in targets)
        {
            timer.elapsedTime += 5;
        }
    }
}
