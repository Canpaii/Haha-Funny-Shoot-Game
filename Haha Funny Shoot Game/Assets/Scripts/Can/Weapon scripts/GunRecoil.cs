using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public float shakeAmount; // Amount of shaking
    public float recoilAmount; // Amount of upward recoil
    public float recoilSpeed; // Speed of recoil animation
    public float shakeSpeed; // Speed of shaking animation
    public float resetPOS; // Speed pos reset

    private Vector3 originalPosition; 

    void Update()
    {
        originalPosition = transform.localPosition;
    }

    public void Shoot()
    {
        // Recoil
        Vector3 recoilPosition = transform.localPosition + Vector3.up * recoilAmount;
        transform.localPosition = Vector3.Lerp(transform.localPosition, recoilPosition, recoilSpeed * Time.deltaTime);

        // Shake
        float shakeX = Random.Range(-1f, 1f) * shakeAmount;
        float shakeY = Random.Range(-1f, 1f) * shakeAmount;
        Vector3 shakeOffset = new Vector3(shakeX, shakeY, 0f);
        transform.localPosition += shakeOffset * shakeSpeed * Time.deltaTime;

        // Reset gun position 
        Invoke("ResetPosition", 0.1f);
    }

    void ResetPosition()
    {
        transform.localPosition = originalPosition;
    }
}
