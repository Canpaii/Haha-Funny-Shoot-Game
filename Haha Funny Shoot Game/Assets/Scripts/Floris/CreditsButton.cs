using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButton : MonoBehaviour
{
    public GameObject creditsText;
    public GameObject creditsButton;
    public GameObject returnButtonCredits;
    public GameObject controlsButton;
    public GameObject returnButtonSettings;
    public void ButtonPress()
    {
        creditsText.SetActive(true);
        returnButtonCredits.SetActive(true);
        creditsButton.SetActive(false);
        controlsButton.SetActive(false);
        returnButtonSettings.SetActive(false);
    }
}
