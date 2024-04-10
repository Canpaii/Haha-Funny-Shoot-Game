using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject loadingScreen;
    public void MoveToScene (int sceneID)
    {
        loadingScreen.SetActive (true);
        SceneManager.LoadScene (sceneID);
    }
}
