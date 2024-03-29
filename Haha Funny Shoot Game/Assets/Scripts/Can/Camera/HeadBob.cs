using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [Header("Walking Headbob")]
    [SerializeField, Range(0f, 0.1f)] private float amplitude;
    [SerializeField, Range(0, 30)] private float frequency;

    [SerializeField, Range(0, 10)] private float smooth;

    private Vector3 startPos;
    [Header("Sprinting Headbob")]
    [SerializeField, Range(0f, 0.1f)] private float sprintAmplitude;
    [SerializeField, Range(0, 30)] private float sprintFrequency;

    [SerializeField, Range(0, 10)] private float sprintSmooth;
    [SerializeField, Range(0, 10)] private float returnSpeed;
    [SerializeField] private GameObject player;
    private BasicMovement sprinting;
    [SerializeField] private GunScript gun;
    [SerializeField] private GunScript gun2;
    private void Awake()
    {
        startPos = transform.localPosition;
        sprinting = player.GetComponent<BasicMovement>();
    }
    private void Update()
    {
        CheckMotion();
        ResetPosition();
    }
    private void CheckMotion()
    {
        float inputMagnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;
        if (inputMagnitude > 0 && !gun.zoomed && !gun2.zoomed)
        {
            FootStepMotion();
        }
    }
    private Vector3 FootStepMotion()
    {
        float currentFrequency = sprinting.sprinting ? sprintFrequency : frequency;
        float currentAmplitude = sprinting.sprinting ? sprintAmplitude : amplitude;
        float currentSmooth = sprinting.sprinting ? sprintSmooth : smooth;

        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * currentFrequency) * currentAmplitude * 1.4f, currentSmooth * Time.deltaTime);
        pos.x += Mathf.Lerp(pos.x, Mathf.Sin(Time.time * currentFrequency / 2f) * currentAmplitude * 1.6f, currentSmooth * Time.deltaTime);
        transform.localPosition += pos;
            
        return pos;
    }
    private void ResetPosition()
    {
        if (transform.localPosition == startPos)
        {
            return;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, startPos, returnSpeed * Time.deltaTime);
    }
}
