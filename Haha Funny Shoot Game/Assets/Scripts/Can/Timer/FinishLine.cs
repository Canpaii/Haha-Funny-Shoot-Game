using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public TMP_Text highScoreText;
    public Timer timer;
    public TimerPenalty penalty;

    public void Start()
    {
        UpdateHighScoreDisplay();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            penalty.CalculatePenalty();
            timer.StopRunning();
            print("Passed thorugh");
            FinishRun();
        }

    }
    public void FinishRun()
    {
        if (!PlayerPrefs.HasKey("HighScore") || timer.elapsedTime <= PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", timer.elapsedTime);
            PlayerPrefs.Save();
            UpdateHighScoreDisplay();
        }
        else
        {
            print("Failed to update highscore");
        }
    }
    public void UpdateHighScoreDisplay()
    {
        if (PlayerPrefs.HasKey("HighScore")){
            highScoreText.text = "High Score: " + timer.FormatTime(PlayerPrefs.GetFloat("HighScore"));
        }
    }
}
