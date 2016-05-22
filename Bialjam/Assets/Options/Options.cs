using UnityEngine;
using System.Collections;

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

    }
    void OnGUI()
    {
        GUI.skin = mySkin;
        if (LightManager.Instance.IsOn)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 128, Screen.height / 2 - 32, 256, 64), "Nightmode ON"))
                LightManager.Instance.SetLights(true);
        }
        if (!LightManager.Instance.IsOn)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 128, Screen.height / 2 - 32, 256, 64), "Nightmode OFF"))
                LightManager.Instance.SetLights(false);
        }
    }
}