﻿using UnityEngine;
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
        GUI.Label(new Rect(10, 10, 256, 64), "Level: " + GlobalVariable.Instance.level);
        GUI.Label(new Rect(10, 40, 256, 64), "Score: " + GlobalVariable.Instance.score);
    }
}