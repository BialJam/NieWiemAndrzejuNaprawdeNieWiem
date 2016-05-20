using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	private float shoot_speed = 0.5f;
	//public bool need_to_live = 0;
	public GameObject bullet=null;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// Initiate the bullet and store in shot var
		//GameObject shot = GameObject.Instantiate (bullet, transform.position + (transform.forward * 2), transform.rotation);

		// Add force to the instance
		//shot.rigidbody.AddForce(transform.forward * shoot_speed);

	//	private Vector2 vector = new Vector2();
	}
}
