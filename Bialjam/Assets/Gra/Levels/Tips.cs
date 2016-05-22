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
		if (GlobalVariable.Instance.tipsShown)
			return;
        czas =  System.DateTime.Now.Second;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
	{
		if (GlobalVariable.Instance.tipsShown)
			return;
        if (System.DateTime.Now.Second - czas > 5)
        {
            Time.timeScale = 1;
            czas = 999999;
			GlobalVariable.Instance.tipsShown = true;
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
