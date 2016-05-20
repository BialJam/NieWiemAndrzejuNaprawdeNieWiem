using UnityEngine;
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
