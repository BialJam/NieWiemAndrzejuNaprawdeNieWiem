﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Vector2 speed;
	public GameObject BulletBody;
	void Start() {
	}
	
	// Update is called once per frame
	void Update () {
		//position += speed;
	}

	void OnGUI() {

	}

	void onCollision(Vector2 playerPosition) {
		//Bullet v1 = new Bullet();
		//Bullet v2 = new Bullet ();
		//v1.speed = Quaternion.AngleAxis (-45, Vector2.right) * speed;
		//v2.speed = Quaternion.AngleAxis (45, Vector2.right) * speed;
	}
}
