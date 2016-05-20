﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    public GUISkin mySkin;
    public static bool paused;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            if (!paused)
            {
                paused = true;
                Time.timeScale = 0;
            }
            else
            {
                paused = false;
                Time.timeScale = 1;
            }
        }

    }

    void OnGUI()
    {
        GUI.skin = mySkin;
        int siz = GlobalVariable.Instance.buttonSize;
        if (paused)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 - 58 * siz, 128 * siz, 32 * siz), "Return"))
            {
                paused = false;
                Time.timeScale = 1;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 - 16 * siz, 128 * siz, 32 * siz), "Options"))
            {
                SceneManager.LoadScene("Options");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 + 26 * siz, 128 * siz, 32 * siz), "Exit"))
            {
                Debug.Log("Game aborted");
                paused = false;
                Time.timeScale = 1;
                SceneManager.LoadScene("Menu");
            }
        }
    }
}