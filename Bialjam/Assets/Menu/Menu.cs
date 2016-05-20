﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GUISkin mySkin;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        int siz = GlobalVariable.Instance.buttonSize;
        if (GUI.Button(new Rect(Screen.width / 2 - 64*siz, Screen.height / 2 - 58 * siz, 128 * siz, 32 * siz), "Start game"))
        {
            Buttons.StartGame();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 - 16 * siz, 128 * siz, 32 * siz), "Options"))
        {
            SceneManager.LoadScene("Options");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 + 26 * siz, 128 * siz, 32 * siz), "Exit"))
        {
            Buttons.ExitGame();
        }
    }
}
