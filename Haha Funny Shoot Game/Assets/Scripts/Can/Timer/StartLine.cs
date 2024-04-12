using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour
{
    public GameObject timer;
    public GameObject[] spawnScript;
    public Collider col;
    public Collider col2;
    public TimerPenalty timerPenalty;
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == ("Player") && !timer.GetComponent<Timer>().isRunning)
        {
            col.GetComponent<Collider>().isTrigger = false;
            col2.GetComponent<Collider>().isTrigger = true;

            foreach (GameObject target in timerPenalty.targets)
            {
               Destroy(target);
            }

            timerPenalty.targets.Clear();

            foreach (GameObject spawner in spawnScript)
            {
                spawner.GetComponent<SpawnScript>().Spawn();
            }

            timer.GetComponent<Timer>().StartRunning();
        }
    }
}
