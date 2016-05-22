using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
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
        GUI.TextField(new Rect(Screen.width / 2 - 400, 50, 800, 200), "Sfera Sprawiedliwosci");
    }
}
