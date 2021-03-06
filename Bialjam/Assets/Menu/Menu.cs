﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class Menu : MonoBehaviour
{
    public GUISkin mySkin;
    // Use this for initialization
    void Start()
    {
        GlobalVariable.Instance.highscore = int.Parse(File.ReadAllText(Application.dataPath + "/highscore.txt"));
        GlobalVariable.Instance.bestname = File.ReadAllText(Application.dataPath + "/bestname.txt");
		MusicManager.Instance.Init ();
    }

    // Update is called once per frame
    void Update()
    {
		MusicManager.Instance.Init ();
    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        int siz = GlobalVariable.Instance.buttonSize;
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 - 58 * siz, 128 * siz, 32 * siz), "Start game"))
        {
            Buttons.StartGame();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 - 16 * siz, 128 * siz, 32 * siz), "Options"))
        {
            SceneManager.LoadScene("Options");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 + 26 * siz, 128 * siz, 32 * siz), "Credits"))
        {
            SceneManager.LoadScene("Credits");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 + 68 * siz, 128 * siz, 32 * siz), "Exit"))
        {
            Buttons.ExitGame();
        }
        if (GUI.Button(new Rect(10, Screen.height - 74, 256, 64), "Normal"))
        {
            GlobalVariable.Instance.hardcore = false;
        }
        if (GUI.Button(new Rect(Screen.width - 266, Screen.height - 74, 256, 64), "Hardcore"))
        {
            GlobalVariable.Instance.hardcore = true;
        }
        if (!GlobalVariable.Instance.hardcore)
            GUI.Label(new Rect(Screen.width / 2 - 128, Screen.height - 74, 256, 64), "Normal");
        else
            GUI.Label(new Rect(Screen.width / 2 - 128, Screen.height - 74, 256, 64), "Hardcore");

    }
}
