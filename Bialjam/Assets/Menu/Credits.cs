using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GUISkin mySkin;
    private float czas;
    // Use this for initialization
    void Start()
    {
        czas = Time.time;
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
        GUI.TextArea(new Rect(0, 1000 - ((Time.time-czas) * 60), Screen.width, 1000),
            //"Grafika:\nTomasz Sierko\nImplementacja:\nPaweł Charyło\nBartosz Pieszko\nNorbert Poniatowski\n"
            //"\nTomasz Sierko\n\n\nGrafika:\n\n\nPaweł Charyło\nBartosz Pieszko\nNorbert Poniatowski\n\n\nImplementacja:\n\n\nNie wiem Andrzeju, na prawdę nie wiem\n\n\nSfera Sprawiedliwosci Deluks"
            "Sfera Sprawiedliwości Deluks\n\nNie wiem Andrzeju, naprawdę nie wiem.\n\n\nImplementacja:\n\nPaweł Charyło\nBartosz Pieszko\nNorbert Poniatowski\n\n\nGrafika:\n\nTomasz Sierko\n\n\nMuzyka:\n\nModigs - Sweet & Sour\nModigs - Rad Racer\nKaloryfer\n\n\nBialjam 2k16\n"
            );

    }
}
