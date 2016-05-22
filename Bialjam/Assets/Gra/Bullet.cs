using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public SpriteRenderer BulletBody;
	public GameObject Shooter;
	public GameObject BulletLight;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		/*if (transform.rotation.y == 180) {
			transform.
		}*/
		if (BulletLight.transform.position.z > 0) {
			Vector3 sc = BulletLight.transform.localPosition;
			sc.z *= -1;
			BulletLight.transform.localPosition = sc;
		}
    }

	void SetShooter(GameObject s) {
		Shooter = s;
		CheckTransform ();
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
				int degree_multiplier = 1;
				if (!BulletBody.flipX)
					degree_multiplier = 3;
				BulletBody.flipX = true;
				GameObject Temporary_Bullet_Handler;
				Temporary_Bullet_Handler = Instantiate (gameObject, GetComponent<Collider2D> ().transform.position, transform.rotation) as GameObject;
				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
				Temporary_Bullet_Handler.layer = 11;
				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Rigidbody2D Temporary_RigidBody;
				Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D> ();
				Destroy (Temporary_Bullet_Handler, 10.0f); // destruct after 10 seconds
				Temporary_RigidBody.AddForce (Quaternion.Euler (0, 0, -45 * degree_multiplier) * -gameObject.transform.right * GlobalVariable.Instance.BulletForwardForce);
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				GetComponent<Rigidbody2D> ().AddForce (Quaternion.Euler (0, 0, 45 * degree_multiplier) * -gameObject.transform.right * GlobalVariable.Instance.BulletForwardForce);
				Destroy (gameObject, 10.0f);
				Vector3 rot = new Vector3 (0, 0, 1);
				transform.RotateAround (rot, Mathf.Deg2Rad * 45 * degree_multiplier);
				Temporary_Bullet_Handler.transform.RotateAround (rot, Mathf.Deg2Rad * -45 * degree_multiplier);
				GlobalVariable.Instance.playerHealth -= 5;

				Temporary_Bullet_Handler.SendMessage ("SetShooter", Shooter);
			} else if (coll.gameObject.layer == 9) { // enemy
				if (coll.gameObject != Shooter) {
					coll.gameObject.SendMessage ("OnDamage");
					GlobalVariable.Instance.score += 100;
					GlobalVariable.Instance.shake = true;
					Destroy (coll.gameObject); // enemy dies
					GlobalVariable.Instance.enemies--;
				}
				Destroy (gameObject);	  // bullet does as well
			} else if (coll.gameObject.layer == 13) { // platform
				Destroy (gameObject);
			} else if (coll.gameObject.layer == 14 && gameObject.layer == 11) { // Ziomek
				Debug.Log("trafienie ziomsona");
				Destroy(coll.gameObject);
				Time.timeScale = 0;
				Buttons.LosedGame ();
			}
		}
	}
	void CheckTransform() {
		if (transform.rotation.y > 0.5) { // can be only (around) 0 or 1
			Debug.Log ("Shall rotate!");
			transform.Rotate (Vector3.up * 180);
			BulletBody.flipX ^= true;
		}
	}
}
