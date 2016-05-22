using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public GameObject body;
    public AudioClip DeadSound;
    public AudioClip powerupSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void playSound()
    {
        gameObject.AddComponent<AudioSource>().PlayOneShot(DeadSound);
    }
    void powerup()
    {
        gameObject.AddComponent<AudioSource>().PlayOneShot(powerupSound);
    }
}
