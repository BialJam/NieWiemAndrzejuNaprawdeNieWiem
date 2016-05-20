using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
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
        if (paused)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 - 58, 128, 32), "Start game"))
            {
                Time.timeScale = 1;
                Debug.Log("Game started");
                SceneManager.LoadScene("Game");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 - 16, 128, 32), "Options"))
            {
                SceneManager.LoadScene("Options");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 + 26, 128, 32), "Exit"))
            {
                Debug.Log("Quit Game");
                Application.Quit();
            }
        }
    }
}
