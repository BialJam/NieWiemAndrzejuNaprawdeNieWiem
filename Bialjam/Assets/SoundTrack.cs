using UnityEngine;
using System.Collections;

public class SoundTrack : MonoBehaviour
{

    private static SoundTrack instance = null;
    public static SoundTrack Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
