using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField, Range(0f, 0.1f)] private float amplitude;
    [SerializeField, Range(0, 30)] private float frequency;

    [SerializeField, Range(0, 10)] private float smooth;

    private Vector3 startPos;
    private void Awake()
    {
        startPos = transform.localPosition;
    }
    private void Update()
    {
        CheckMotion();
        ResetPosition();
    }
    private void CheckMotion()
    {
        float inputMagnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;
        if (inputMagnitude > 0)
        {
            FootStepMotion();
        }
    }
    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * frequency) * amplitude * 1.4f, smooth * Time.deltaTime);
        pos.x += Mathf.Lerp(pos.x, Mathf.Sin(Time.time * frequency / 2f) * amplitude * 1.6f, smooth * Time.deltaTime);
        transform.localPosition += pos
            ;
        return pos;
    }
    private void ResetPosition()
    {
        if (transform.localPosition == startPos)
        {
            return;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, startPos,1 * Time.deltaTime);
    }
}
