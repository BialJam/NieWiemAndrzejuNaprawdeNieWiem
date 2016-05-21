using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lose : MonoBehaviour
{
    public GUISkin mySkin;
    public InputField inputfield;
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
        GUI.Label(new Rect(Screen.width / 2 - 256, Screen.height / 2 - 230, 512, 64), "Best player: " + GlobalVariable.Instance.bestname + " | " + GlobalVariable.Instance.highscore);
        GUI.Label(new Rect(Screen.width / 2 - 256, Screen.height / 2 - 166, 512, 64), "Your score: " + GlobalVariable.Instance.score);
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 - 12 * siz, 128 * siz, 32 * siz), "Save score"))
        {
            Buttons.SaveScore(inputfield.text);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 + 24 * siz, 128 * siz, 32 * siz), "Start new game"))
        {
            Buttons.StartGame();
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 64 * siz, Screen.height / 2 + 60 * siz, 128 * siz, 32 * siz), "Menu"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
