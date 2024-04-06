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
    public Collider col;

    public void Start()
    {
        UpdateHighScoreDisplay();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            col.isTrigger = true;
            penalty.CalculatePenalty();
            print("Passed thorugh");
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
        else if (timer.elapsedTime >= PlayerPrefs.GetFloat("HighScore"))
        {
            print("Highscore not reached");
        }
        else
        {
            print("Error with highscore");
        }
    }
    public void UpdateHighScoreDisplay()
    {
        if (PlayerPrefs.HasKey("HighScore")){
            highScoreText.text = "High Score: " + timer.FormatTime(PlayerPrefs.GetFloat("HighScore"));
        }
    }
}
