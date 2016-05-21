﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class Level : MonoBehaviour
{
    public GameObject pauseBackground;
    public GUISkin mySkin;
    public static bool paused;
    public int enemies;
    // Use this for initialization
    void Start()
    {
        GlobalVariable.Instance.level++;
        Time.timeScale = 1;
        paused = false;
        pauseBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (DateTime.Now.Second % 5 == 0 && DateTime.Now.Millisecond < 50) GlobalVariable.Instance.score += 5;
        }
        if (Input.GetKey("escape"))
        {
            if (!paused)
            {
                pauseBackground.SetActive(true);
                paused = true;
                Time.timeScale = 0;
                Thread.Sleep(100);
            }
            else
            {
                pauseBackground.SetActive(false);
                paused = false;
                Time.timeScale = 1;
                Thread.Sleep(100);
            }
        }
        if (GlobalVariable.Instance.GetPlayerHealth() <= 0)
        {
            Time.timeScale = 0;
            Buttons.LosedGame();
        }
        if (enemies <= 0)
        {
            GlobalVariable.Instance.score += GlobalVariable.Instance.playerHealth * 10;
            GlobalVariable.Instance.ChangePlayerHealth(25);
            SceneManager.LoadScene("Level " + GlobalVariable.Instance.level);
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
                pauseBackground.SetActive(false);
                paused = false;
                Time.timeScale = 1;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 - 16 * siz, 128 * siz, 32 * siz), "Options"))
            {
                SceneManager.LoadScene("Options");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 + 26 * siz, 128 * siz, 32 * siz), "Exit"))
            {
                pauseBackground.SetActive(false);
                Debug.Log("Game aborted");
                paused = false;
                Time.timeScale = 1;
                SceneManager.LoadScene("Menu");
            }
        }
    }
}