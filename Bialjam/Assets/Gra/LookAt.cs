using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//target = GameObject.Find ("Me");
		//transform.LookAt (target.transform);
		transform.Rotate (Vector3.up * 90);
		Vector3 object_pos, player_pos;
		float angle;
		player_pos = Camera.main.WorldToScreenPoint(GameObject.Find ("Player_1").transform.position);
		object_pos = Camera.main.WorldToScreenPoint(transform.position);
		angle = Mathf.Atan2(player_pos.y - object_pos.y, player_pos.x - object_pos.x) * Mathf.Rad2Deg + 180;
		if (angle % 60 > 30)
			angle += 60;
		angle -= angle % 60;
		int x = 360;
		int y = 0;
		if( angle < 90 || angle > 270 ){
			y = 180;
			x = 180;
		}
		transform.rotation = Quaternion.Euler(new Vector3(x, y, angle));

	}
}