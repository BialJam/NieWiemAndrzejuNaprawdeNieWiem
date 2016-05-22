using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManager {
	AudioClip ST1;
	AudioClip ST2;
	AudioClip ST3;
	AudioSource AS;
	int track;
	public void Init() {
		if (!ST1)
			ST1 = Resources.Load("Music/Modigs - Rad Racer", typeof(AudioClip)) as AudioClip;

		if (!ST2)
			ST2 = Resources.Load("Music/Modigs - Sweet & Sour", typeof(AudioClip)) as AudioClip;

		if (!ST3)
			ST3 = Resources.Load("Music/kaloryfer", typeof(AudioClip)) as AudioClip;
		
		if (!AS) {
			GameObject o = new GameObject();
			AS = o.AddComponent<AudioSource> ();
			AS.clip = ST1;
			track = 1;
			AS.loop = true;
			AS.volume = 0.8f;
			GameObject.DontDestroyOnLoad (AS);
		}
		if (!AS.isPlaying)
			AS.Play ();
	}
	public void StartST(int i) {
		if (i == 1)
			AS.clip = ST1;
		else if (i == 2)
			AS.clip = ST2;
		else if (i == 3)
			AS.clip = ST3;
		track = i;
		AS.Play ();
	}
	public string GetTrackTitle() {
		if (track == 1) 
			return "Modigs - Rad Racer";
		if (track == 2)
			return "Modigs - Sweet & Sour";
		if (track == 3) 
			return "Kaloryfer";
		return "?";
	}
	public void PlayNextTrack() {
		int i = track + 1;
		if (i > 2)
			i = 1;
		StartST (i);
	}
	private static MusicManager instance;
	public static MusicManager Instance
	{
		get
		{
			if(instance==null)
			{
				instance = new MusicManager();
				instance.Init ();
			}
			return instance;
		}
	}
}
