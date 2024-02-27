using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwap : MonoBehaviour
{
    public GameObject primaryGun;
    public GameObject secondaryGun;
    public float scrollInput;
    void Update()
    {
        scrollInput = Input.GetAxisRaw("Mouse ScrollWheel");
        if (scrollInput > 0 && !secondaryGun.GetComponent<GunScript>().zoomed)
        {
            SwitchToPrimaryGun();
        }
        else if (scrollInput < 0 && !primaryGun.GetComponent<GunScript>().zoomed)
        {
            SwitchToSecondaryGun();
        }
    }

    void SwitchToPrimaryGun()
    {
        primaryGun.SetActive(true);
        secondaryGun.SetActive(false);
    }

    void SwitchToSecondaryGun()
    {
        primaryGun.SetActive(false);
        secondaryGun.SetActive(true);
    }
}

