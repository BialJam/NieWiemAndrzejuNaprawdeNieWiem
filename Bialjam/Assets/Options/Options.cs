﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GUISkin mySkin;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    void OnGUI()
    {

        GUI.skin = mySkin;
        int siz = GlobalVariable.Instance.buttonSize;
        if (LightManager.Instance.IsOn)
        {
			if (GUI.Button(new Rect(Screen.width / 2 - 128, Screen.height / 2 - 106, 256, 64), "Nightmode ON")) {
                LightManager.Instance.SetLights(false);
			}
        }
        else
        {
			if (GUI.Button (new Rect (Screen.width / 2 - 128, Screen.height / 2 - 106, 256, 64), "Nightmode OFF")) {
				LightManager.Instance.SetLights (true);
			}
        }
		if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 32, 300, 64), MusicManager.Instance.GetTrackTitle()))
		{
			MusicManager.Instance.PlayNextTrack();
        }

    }
}
