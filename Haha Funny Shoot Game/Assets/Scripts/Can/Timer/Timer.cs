
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTimer;
    public bool isRunning = false;
    public float elapsedTime;

    public void StartRunning()
    {
        timerText.text = "0:00.00";
        startTimer = Time.time;
        isRunning = true;
        timerText.text = FormatTime(elapsedTime);
    }
    public void StopRunning()
    {
        isRunning = false;
    }
    private void Update()
    {
        if (isRunning)
        {
            elapsedTime = Time.time - startTimer;
            timerText.text = FormatTime(elapsedTime);
        }
    }

    public string FormatTime(float elapsedTime)
    {
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        float miliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);

        return string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, miliseconds);
    }
}
