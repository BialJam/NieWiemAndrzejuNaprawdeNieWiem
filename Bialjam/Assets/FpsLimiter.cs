using UnityEngine;
using System.Collections;

public class FpsLimiter : MonoBehaviour {
    public int FPS = 10;
	// Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
