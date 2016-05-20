using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	private bool shoot_speed;
	public Bullet bullet;
	public const bool need_to_live; 
	// Use this for initialization
	void Start (bool first, bool second) {
		shoot_speed = first;
		need_to_live = second;
	}
	
	// Update is called once per frame
	void Update () {
		
	//	private Vector2 vector = new Vector2();
	}
}
