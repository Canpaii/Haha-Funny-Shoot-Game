using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public TMP_Text highScoreText;
    public Timer timer;
    public float highScore;
    public void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", Mathf.Infinity);
        UpdateHighScoreDisplay();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == ("Player"))
        {
            timer.isRunning = false;
            timer.startTimerFlag = false;
            FinishRun();
        }
    }
    public void FinishRun()
    {
        if (timer.elapsedTime < highScore || !PlayerPrefs.HasKey("HighScore"))
        {
            highScore = timer.elapsedTime;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();

            UpdateHighScoreDisplay();
        }
    }
    public void UpdateHighScoreDisplay()
    {
        highScoreText.text = "High Score: " + FormatTime(highScore);
    }
    string FormatTime(float highScore)
    {

        float minutes = Mathf.FloorToInt(timer.elapsedTime / 60);
        float seconds = Mathf.FloorToInt(timer.elapsedTime % 60);
        float miliseconds = Mathf.FloorToInt((timer.elapsedTime * 100) % 100);

        return string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, miliseconds);
    }
}
