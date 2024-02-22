using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [Header("Spawns & Targets")]
    public GameObject[] spawner;
    public GameObject[] target;

    private int i;
    private int j;

    public void Start()
    {
        i = Random.Range(0, spawner.Length);
        j = Random.Range(0, target.Length);
        Instantiate(target[j], spawner[i].transform.position, spawner[i].transform.rotation);
    }

}
