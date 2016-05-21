using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	private bool OnGround;
	public Transform JumpCheck;
	public float speed=1f;
	public float JumpForce;
	private float JumpTime;
	private float JumpDelay=.5f;
	private bool jumped;
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
		OnGround = Physics2D.Linecast (transform.position, JumpCheck.position, 1 << LayerMask.NameToLayer("ground"));
		Physics2D.IgnoreLayerCollision (8, 10);
	}
	void MovementFunct(){
		anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis("Horizontal")));
		//Debug.Log (Mathf.Abs (Input.GetAxis ("Horizontal")));
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
		if (Input.GetKeyDown (KeyCode.Space) && OnGround ) {
			anim.SetTrigger ("Jump");
			GetComponent<Rigidbody2D> ().AddForce (transform.up * JumpForce);
			Debug.Log ("jump");
			jumped = true;
			JumpTime = JumpDelay;
		}
		JumpTime -= Time.deltaTime;
		if ((JumpTime <= 0 && jumped) || (OnGround && jumped)) {
			jumped = false;
		}
	}
}
