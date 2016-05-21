using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
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
        GUI.Label(new Rect(5, 5, 256, 40), "Score: " + GlobalVariable.Instance.score);
        GUI.Label(new Rect(Screen.width - 261, 5, 256, 40), "Level: " + GlobalVariable.Instance.level);
        GUI.Label(new Rect(Screen.width / 2 - 128, Screen.height - 45, 256, 40), "Health: " + GlobalVariable.Instance.playerHealth);
        GUI.Label(new Rect(Screen.width / 2 - 128, 10, 256, 40), "Enemies left: " + GlobalVariable.Instance.enemies);
    }
}
