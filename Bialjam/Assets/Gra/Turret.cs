using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	private const bool shoot_speed;
	public GameObject Bullet;
	public const bool need_to_live; 
	// Use this for initialization
	void Start (bool first, bool second) {
		shoot_speed = first;
		need_to_live = second;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPosition = Me.TransformPoint(new Vector3(0, 5, -10));
	}
}
