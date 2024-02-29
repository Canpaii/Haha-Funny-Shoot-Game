using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FToTalk : MonoBehaviour
{
    public GameObject yes1;
    public GameObject ok1;
    public GameObject no1;
    public GameObject ok2;

    public GameObject hello;
    public GameObject uitleg;
    public GameObject veelSucces;

    public void Start()
    {
        yes1.SetActive(false);
        ok1.SetActive(false);
        no1.SetActive(false);
        ok2.SetActive(false);
        hello.SetActive(false);
        uitleg.SetActive(false);
        veelSucces.SetActive(false);
    }

    // Update is called once per frame
    public void Hello()
    {
        Cursor.visible = true;
         
        yes1.SetActive (true);
        no1.SetActive (true);
        hello.SetActive (true);     
    }

    public void explain()
    {
        yes1 .SetActive (false);
        no1 .SetActive (false);
        hello .SetActive (false);

        uitleg .SetActive (true);
        ok1.SetActive (true);
    }

    public void doei()
    {
        uitleg.SetActive (false);
        ok1.SetActive (false);

        ok2.SetActive (true);
        veelSucces.SetActive (true);
    }

    public void echtDoei()
    {
        ok2.SetActive(false);
        veelSucces.SetActive (false);

        Cursor.visible = false;
    }
}
