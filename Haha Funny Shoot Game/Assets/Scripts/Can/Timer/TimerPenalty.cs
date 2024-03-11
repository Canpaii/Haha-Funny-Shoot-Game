using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPenalty : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    public Timer timer;
    public FinishLine finish;
    private TargetHit hit; 
    public void CalculatePenalty()
    {
        timer.StopRunning();
        foreach (GameObject target in targets)
        {
            hit = target.GetComponent<TargetHit>();
            if (!hit.hit)
            {
                timer.elapsedTime += 5;
            }
            else
            {
                print("Target Hit");
            }
        }
        finish.FinishRun();
    }
}
