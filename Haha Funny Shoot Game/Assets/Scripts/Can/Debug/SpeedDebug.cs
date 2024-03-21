using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedDebug : MonoBehaviour
{
    public TMP_Text speed;
    public GameObject player;

    private void Update()
    {
        speed.text = player.GetComponent<Rigidbody>().velocity.magnitude.ToString();
    }
}
