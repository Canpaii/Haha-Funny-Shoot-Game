
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTimer;
    private bool isRunning;

    private void Start()
    {
        timerText.text = "0:00.00";
        isRunning = false;
    }
    private void Update()
    {
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

        timerText.text = string.Format("{0:000}:{1:00}.{2:000}", minutes, seconds, miliseconds);
    }
}
