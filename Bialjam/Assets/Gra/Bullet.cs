using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public GameObject BulletBody;
	public GameObject Shooter;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

	void SetShooter(GameObject s) {
		Shooter = s;
	}
	void SetShooterForBullet(GameObject s) {
		s.SendMessage ("SetShooter", Shooter);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("We have a collision here!");
		if (coll.gameObject) {
			if (coll.gameObject.layer == 10) { // Player's layer
				gameObject.layer = 11;
				GameObject Temporary_Bullet_Handler;
				Temporary_Bullet_Handler = Instantiate (gameObject, GetComponent<Collider2D> ().transform.position, transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
				Temporary_Bullet_Handler.layer = 11;
				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Rigidbody2D Temporary_RigidBody;
				Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D> ();
				Destroy (Temporary_Bullet_Handler, 10.0f); // destruct after 10 seconds
				Temporary_RigidBody.AddForce (Quaternion.Euler (0, 0, -45) * -gameObject.transform.right * GlobalVariable.Instance.BulletForwardForce);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				GetComponent<Rigidbody2D> ().AddForce (Quaternion.Euler (0, 0, 45) * -gameObject.transform.right * GlobalVariable.Instance.BulletForwardForce);
				Destroy (gameObject, 10.0f);
				Vector3 rot = new Vector3 (0, 0, 1);
				transform.RotateAround (rot, Mathf.Deg2Rad * 45);
				Temporary_Bullet_Handler.transform.RotateAround (rot, Mathf.Deg2Rad * -45);
				GlobalVariable.Instance.playerHealth -= 5;

				Temporary_Bullet_Handler.SendMessage ("SetShooter", Shooter);
			} else if (coll.gameObject.layer == 9) { // enemy
				if (coll.gameObject != Shooter)
					Destroy (coll.gameObject); // enemy dies
				Destroy (gameObject);	  // bullet does as well
			} else if (coll.gameObject.layer == 13) { // platform
				Destroy (gameObject);
			}else if (coll.gameObject.layer == 8) { // bullets destroy each other
				Destroy (gameObject);
				Destroy (coll.gameObject);
			}
		}
	}
}
