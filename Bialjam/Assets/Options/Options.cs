using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GUISkin mySkin;
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
		if (GUI.Button (new Rect (Screen.width / 2 - 256, Screen.height / 2 - 138, 512, 128), "Nightmode " + (LightManager.Instance.IsOn ? "ON" : "OFF"))) {
			LightManager.Instance.SetLights(!LightManager.Instance.IsOn);
		}
		if (GUI.Button(new Rect(Screen.width / 2 - 256, Screen.height / 2 + 10, 512, 128), "Music: " + MusicManager.Instance.GetTrackTitle()))
		{
			MusicManager.Instance.PlayNextTrack();
        }

    }
}