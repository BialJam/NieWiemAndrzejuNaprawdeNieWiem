using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Vector2 speed;
	Vector2 position;
	Bullet(Vector2 pos, Vector2 speed) {
		position = pos;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollision() {
		//Bullet v1 = new Bullet (PLAYER.position, Quaternion.AngleAxis (-45, Vector2.right) * speed);
		//Bullet v2 = new Bullet (PLAYER.position, Quaternion.AngleAxis (45, Vector2.right) * speed);
	}
}
