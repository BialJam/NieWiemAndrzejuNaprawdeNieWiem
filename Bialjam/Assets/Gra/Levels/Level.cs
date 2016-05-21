using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Level : MonoBehaviour
{
    public GameObject pauseBackground;
    public GUISkin mySkin;
    public static bool paused;
    // Use this for initialization
    void Start()
    {
        GlobalVariable.Instance.level++;
        GlobalVariable.Instance.SetPlayerHealth(100);
        Time.timeScale = 1;
        paused = false;
        pauseBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale==1)
        {
            GlobalVariable.Instance.ChangePlayerHealth(-1);
            if (DateTime.Now.Second % 5 == 0 && DateTime.Now.Millisecond < 300) GlobalVariable.Instance.score += 5;
        }
        if (Input.GetKey("escape"))
        {
            if (!paused)
            {
                pauseBackground.SetActive(true);
                paused = true;
                Time.timeScale = 0;
            }
            else
            {
                pauseBackground.SetActive(false);
                paused = false;
                Time.timeScale = 1;
            }
        }
        if (GlobalVariable.Instance.GetPlayerHealth()<=0 )
        {
            Time.timeScale = 0;
            Buttons.LosedGame();
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