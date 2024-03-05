using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HideUI : MonoBehaviour
{
    public GameObject yes1;
    public GameObject ok1;
    public GameObject no1;
    public GameObject ok2;

    public GameObject hello;
    public GameObject uitleg;
    public GameObject veelSucces;
    // Start is called before the first frame update
    void Start()
    {
        print("start");
        yes1.SetActive(false);
        ok1.SetActive(false);
        no1.SetActive(false);
        ok2.SetActive(false);
        hello.SetActive(false);
        uitleg.SetActive(false);
        veelSucces.SetActive(false);
    }
}
