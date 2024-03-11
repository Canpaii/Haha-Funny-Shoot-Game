using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [Header("Spawns & Targets")]
    public GameObject[] spawner;
    public GameObject[] target;
    public TimerPenalty timerPenalty;

    private int i;
    private int j;

    public void Spawn()
    {
        i = Random.Range(0, spawner.Length);
        j = Random.Range(0, target.Length);
        timerPenalty.targets.Add(Instantiate(target[j], spawner[i].transform.position, spawner[i].transform.rotation));
    }

}
