using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField] private bool enableBob;

    [SerializeField, Range(0f, 0.1f)] private float amplitude;
    [SerializeField, Range(0, 30)] private float frequency;

    [SerializeField] private Transform _camera;
    [SerializeField] private Transform cameraHolder;

    [SerializeField] private float toggelSpeed;
    [SerializeField] private float lerpSpeed;
    private Vector3 startPos;
    [SerializeField]private Rigidbody player;
    private BasicMovement controller;
    [SerializeField] private Vector3 pos;
    private void Awake()
    {
        controller = GetComponent<BasicMovement>();
        startPos = _camera.localPosition;
    }
    private void Update()
    {
        print(pos);
        if (!enableBob)
        {
            return;
        }
        CheckMotion();
        _camera.LookAt(FocusTarget());
    }
    private void CheckMotion()
    {
        ResetPosition();
        float speed = new Vector3(player.velocity.x, 0, player.velocity.z).magnitude;
        if (speed < toggelSpeed)
        {
            return;
        }
        if (!controller.grounded)
        {
            return;
        }
        PlayMotion(FootStepMotion());
    }
    private Vector3 FootStepMotion()
    {
        pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * frequency * amplitude);
        pos.y += Mathf.Sin(Time.time * frequency/2) * amplitude * 2;
        return pos;
    }
    private void PlayMotion(Vector3 motion)
    {
        _camera.localPosition += motion;
    }
    private void ResetPosition()
    {
        if (_camera.localPosition == startPos)
        {
            return;
        }
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, startPos,lerpSpeed * Time.deltaTime);
    }
    private Vector3 FocusTarget()
    {
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pos += cameraHolder.forward * 15;
        return pos;
    }
    
}
