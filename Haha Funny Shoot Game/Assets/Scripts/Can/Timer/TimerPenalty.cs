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
            TargetLugarPistol hitLuger = target.GetComponent<TargetLugarPistol>();
            TargetM1Garand hitGarand = target.GetComponent<TargetM1Garand>();
            if (!hitLuger.hit || !hitGarand.hit)
            {
                timer.elapsedTime += 5;
                timer.isRunning = false;
            }
        }
    }
}
