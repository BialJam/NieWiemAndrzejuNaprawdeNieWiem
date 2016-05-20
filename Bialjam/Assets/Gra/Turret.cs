using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	//private const bool shoot_speed;
	public GameObject Bullet;
	public GameObject BulletSpawningPoint;
	public GameObject TurretBody;
	public GameObject Player;
	public float BulletForwardForce = 1.0f;
	bool bulletExists = false;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!bulletExists) {
			
			Shoot ();
			bulletExists = true;
		}
		//Vector3 targetPosition = Me.TransformPoint(new Vector3(0, 5, -10));
	}

	void Shoot() {
		GameObject Temporary_Bullet_Handler;
		Temporary_Bullet_Handler = Instantiate(Bullet,BulletSpawningPoint.transform.position,BulletSpawningPoint.transform.rotation) as GameObject;
		Temporary_Bullet_Handler.transform.LookAt (Player.transform);
		//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
		//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
		//Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

		//Retrieve the Rigidbody component from the instantiated Bullet and control it.
		Rigidbody2D Temporary_RigidBody;
		Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();

		//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
		Temporary_RigidBody.AddForce(transform.forward * 1000);

		//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.

		Destroy (Temporary_Bullet_Handler, 10.0f);
	}
}
