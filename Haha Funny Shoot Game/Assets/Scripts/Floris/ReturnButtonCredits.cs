using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButtonCredits : MonoBehaviour
{
    public GameObject creditsText;
    public GameObject creditsButton;
    public GameObject returnButtonCredits;
    public GameObject controlsButton;
    public GameObject returnButtonSettings;
    public void ButtonPress()
    {
        creditsText.SetActive(false);
        returnButtonCredits.SetActive(false);
        creditsButton.SetActive(true);
        controlsButton.SetActive(true);
        returnButtonSettings.SetActive(true);
    }
}
