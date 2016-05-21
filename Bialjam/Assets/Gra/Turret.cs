using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	//private const bool shoot_speed;
	public GameObject Bullet;
	public GameObject BulletSpawningPoint;
	public GameObject TurretBody;
	public GameObject Player;
	public SpriteRenderer Eye;
	public GameObject Aura;
	public Sprite LU, LC, LD, RU, RC, RD;
	public double shootExhaust;
	public double randomExhaust = 5f;
	private double auraExhaust = 10f;
	public bool aura = false;
	private double nextShoot = 0.0f;
	private float nextRandom = 0.0f; //internal
	private double usunAure = 999999999;
	private bool lewo;
	void Start () {
		Player = GameObject.Find ("Player 1");
		Aura.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if ((double)Time.time > nextShoot ) {
			Shoot ();
			nextShoot = Time.time + shootExhaust; 
		}
		if ((double)Time.time > nextRandom ) {
			if (Random.Range (0, 100) >= 90) {
				aura = true;
				usunAure = Time.time + auraExhaust;
				Aura.SetActive(true);
				Debug.Log ("Tworzenie aury");
			}
			nextRandom = Time.time + Random.Range(1.5f, 2.5f);
			Debug.Log ("Los aury");
		}
		if (aura && (double)Time.time > usunAure) {
			usunAure = 999999999;
			Debug.Log ("Usuniecie aury");
			aura = false;
			Aura.SetActive (false);
		}
		//LookAt (Player.transform.position);
		LookAt (Player);
	}

	void Shoot() {
		GameObject Temporary_Bullet_Handler;
		Vector2 Direction = Player.transform.position - BulletSpawningPoint.transform.position;
		Direction.Normalize ();
		Temporary_Bullet_Handler = Instantiate(Bullet,GetComponent<Collider2D>().transform.position,transform.rotation) as GameObject;
		//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
		//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.

		Temporary_Bullet_Handler.transform.LookAt (Player.transform);
		Temporary_Bullet_Handler.transform.Rotate(Vector3.up * 90);
		//Retrieve the Rigidbody component from the instantiated Bullet and control it.
		Rigidbody2D Temporary_RigidBody;
		Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();
		Temporary_RigidBody.AddForce(Direction * GlobalVariable.Instance.BulletForwardForce);
		Destroy (Temporary_Bullet_Handler, 10.0f); // destruct after 10 seconds

		Temporary_Bullet_Handler.SendMessage("SetShooter", gameObject);
	}

	void LookAt(GameObject target) {
		//transform.Rotate (Vector3.up * 90);
		Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position), pos = Camera.main.WorldToScreenPoint(target.transform.position);
		float angle = Mathf.Atan2 (pos.y - object_pos.y, pos.x - object_pos.x) * Mathf.Rad2Deg + 180; 
		/* + 360 - Quaternion.Angle(Quaternion.identity, transform.rotation);
		angle %= 360;*/
		if (angle % 60 > 30)
			angle += 60;
		angle -= angle % 60;
		if (angle < 15 || angle >= 315) {
			Eye.sprite = LC;
			lewo = true;
		} else if (angle < 75) {
			Eye.sprite = LD;
			lewo = true;
		} else if (angle < 135){
			Eye.sprite = RD;
			lewo = false;
		} else if (angle < 195){
			Eye.sprite = RC;
			lewo = false;
		} else if (angle < 255){
			Eye.sprite = RU;
			lewo = false;
		} else if (angle < 315) {
			Eye.sprite = LU;
			lewo = true;
		}
		if (lewo) {
			TurretBody.transform.eulerAngles = new Vector3 (0, 180, 0);
			Aura.transform.localPosition = new Vector3 (.05f, 0, 0);
		} else {
			TurretBody.transform.eulerAngles = new Vector3 (0, 0, 0);
			Aura.transform.localPosition = new Vector3 (-.05f, 0, 0);
		}
	}
	void OnDamage() {
		if (aura) {
			GlobalVariable.Instance.playerHealth += 50;
		}
	}
}
