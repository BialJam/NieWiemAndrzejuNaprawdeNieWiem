using UnityEngine;
using System.Collections;
using System;

public class Tips : MonoBehaviour
{
    private float czas;
    public GUISkin mySkin;
    // Use this for initialization
    void Start()
    {
        czas =  System.DateTime.Now.Second;
        Debug.Log(czas);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (System.DateTime.Now.Second - czas > 5)
        {
            Time.timeScale = 1;
            czas = 999999;
        }
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        if (System.DateTime.Now.Second - czas < 5 && czas!=999999)
        {

            GUI.Label(new Rect(Screen.width / 2 - 256, Screen.height / 2 - 32, 512, 64), "Zabij przeciwników ich pociskami. Przyda Ci się do tego podwójny skok.");
        }
    }
}
