using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        /*highscoreEntryList = new List<HighscoreEntry>() 
        {
            new HighscoreEntry{ score = 521854, name = "AAA" },
            new HighscoreEntry{ score = 358462, name = "ANN" },
            new HighscoreEntry{ score = 785123, name = "CAT" },
            new HighscoreEntry{ score = 15524, name = "JON" },
            new HighscoreEntry{ score = 897621, name = "JOE" },
            new HighscoreEntry{ score = 68245, name = "MIK" },
            new HighscoreEntry{ score = 872931, name = "DAV" },
            new HighscoreEntry{ score = 542024, name = "MAX" },
        };*/

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        /*
        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }
        */

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
 
        /*
        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable")); 
        */
        
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 74f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    
    [System.Serializable]

    private class HighscoreEntry
    {
        public int score;
        public string name;

    }
}
