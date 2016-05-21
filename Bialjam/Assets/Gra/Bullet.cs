using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	
    public GameObject BulletBody;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //position += speed;
    }

	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("We have a collision here!");
		if (coll.gameObject && coll.gameObject.layer == 10) { // Player's layer
			gameObject.layer = 11;
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate(gameObject,GetComponent<Collider2D>().transform.position,transform.rotation) as GameObject;
			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			Temporary_Bullet_Handler.layer = 11;
			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody2D Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
			//Temporary_RigidBody.AddForce(Direction * Vector2.right * 90 * BulletForwardForce);
			Destroy (Temporary_Bullet_Handler, 10.0f); // destruct after 10 seconds
			Temporary_RigidBody.AddForce(Quaternion.Euler(0, 0, -45)*-gameObject.transform.right * GlobalVariable.Instance.BulletForwardForce);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			GetComponent<Rigidbody2D> ().AddForce (Quaternion.Euler(0, 0, 45)*-gameObject.transform.right* GlobalVariable.Instance.BulletForwardForce);
			Destroy (gameObject, 10.0f);
            GlobalVariable.Instance.playerHealth -= 5;
		}
	}
}
