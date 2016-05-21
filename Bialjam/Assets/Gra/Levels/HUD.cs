using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
    public GUISkin mySkin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.skin = mySkin;
        GUI.Label(new Rect(-50, 10, 256, 64), "Score: " + GlobalVariable.Instance.score);
        GUI.Label(new Rect(Screen.width - 256, 10, 256, 64), "Level: " + GlobalVariable.Instance.level);
        GUI.Label(new Rect(Screen.width / 2 - 128, Screen.height-74, 256, 64), "Health: " + GlobalVariable.Instance.playerHealth);
    }
}
