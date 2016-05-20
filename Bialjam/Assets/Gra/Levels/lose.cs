﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour {
    public GUISkin mySkin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if( Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
	}

    void OnGUI()
    {
        GUI.skin = mySkin;
        int siz = GlobalVariable.Instance.buttonSize;
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 - 58 * siz, 128 * siz, 32 * siz), "Save score"))
        {
            Buttons.SaveScore();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 - 16 * siz, 128 * siz, 32 * siz), "Start new game"))
        {
            Buttons.StartGame();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 + 26 * siz, 128 * siz, 32 * siz), "Menu"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
