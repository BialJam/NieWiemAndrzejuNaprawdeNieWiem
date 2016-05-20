using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	//private const bool shoot_speed;
	public GameObject Bullet;
	public GameObject BulletSpawningPoint;
	public GameObject TurretBody;
	public GameObject Player;
	public float BulletForwardForce = 1.0f;
	public double shootExhaust = 100.0f; // seconds
	private double nextShoot = 0.0f; //internal
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextShoot ) {
			Shoot ();
			nextShoot = Time.time + shootExhaust; 
		}
	}

	void Shoot() {
		GameObject Temporary_Bullet_Handler;
		Temporary_Bullet_Handler = Instantiate(Bullet,BulletSpawningPoint.transform.position,BulletSpawningPoint.transform.rotation) as GameObject;
		//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
		//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.

		Temporary_Bullet_Handler.transform.LookAt (Player.transform);
		Temporary_Bullet_Handler.transform.Rotate(Vector3.up * 90);
		//Retrieve the Rigidbody component from the instantiated Bullet and control it.
		Rigidbody2D Temporary_RigidBody;
		Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();

		Temporary_RigidBody.AddForce((Player.transform.position - transform.position - BulletSpawningPoint.transform.position) * 20);
		Destroy (Temporary_Bullet_Handler, 10.0f); // destruct after 10 seconds
	}
}
