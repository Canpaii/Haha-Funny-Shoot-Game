
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTimer;
    public bool startTimerFlag;
    public bool isRunning;

    private void Start()
    {
        timerText.text = "0:00.00";
        isRunning = false;
        startTimerFlag = false;
    }
    private void Update()
    {
        if (startTimerFlag)
        {
            startTimer = Time.time;
            startTimerFlag = false;
        }
        if (isRunning)
        {
            float elapsedTime = Time.time - startTimer;
            UpdateTimer(elapsedTime);
        }
    }

    void UpdateTimer(float elapsedTime)
    {
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float miliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);

        timerText.text = string.Format("{0:000}:{1:00}.{2:00}", minutes, seconds, miliseconds);
    }
}
