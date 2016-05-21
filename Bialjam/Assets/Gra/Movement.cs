﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	private bool OnGround;
	public float speed=1f;
	public float JumpForce;
	private float JumpTime;
	private float JumpDelay=.5f;
	private int jumped;
	private float dif=0.1f;
	public RaycastHit2D[] linecastResult = new RaycastHit2D[1];
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animator> ();
	}
	// Update is called once per frame
	void Update () {
		MovementFunct ();
		RaycastStuff ();
	}

	void RaycastStuff(){
		Physics2D.RaycastNonAlloc ((Vector2)transform.position - new Vector2(0, gameObject.GetComponent<Collider2D>().bounds.size.y/2 + 0.02f), Vector2.down, linecastResult);
		OnGround = linecastResult [0].collider && linecastResult [0].distance < 0.05;
	}
	void MovementFunct(){
		anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis("Horizontal")));
		if (Input.GetAxis ("Horizontal") < 0) {
			transform.Translate (Vector3.right * -1 * speed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (360, 0, 360);
			Debug.Log ("lewo");
		}
		if (Input.GetAxis ("Horizontal") > 0) {
			transform.Translate (Vector3.right * -1 * speed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (360, 180, 360);
			Debug.Log ("prawo");
		}
		if (Input.GetKeyDown (KeyCode.Space) && (OnGround || jumped == 1)) {
			anim.SetTrigger ("Jump");
			GetComponent<Rigidbody2D> ().AddForce (new Vector2(0,JumpForce));
			Debug.Log ("jump");
			jumped ++;
			JumpForce = 0.1f;
			JumpTime = Mathf.Max(JumpDelay, JumpTime + JumpDelay);
		}
		JumpTime -= Time.deltaTime;
		JumpForce=Mathf.Min(250, JumpForce + dif);
		if (JumpForce > 250)
			JumpForce = 10;
		dif +=1;
		if ( JumpTime <= 0 && OnGround ) {
			JumpForce = 250;
			jumped = 0;
			dif = 0.1f;
		}
	}
}
