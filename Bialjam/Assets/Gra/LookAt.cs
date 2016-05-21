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
		Vector3 mouse_pos, object_pos;
		float angle;
		mouse_pos = Input.mousePosition;
		object_pos = Camera.main.WorldToScreenPoint(transform.position);
		angle = Mathf.Atan2(mouse_pos.y - object_pos.y, mouse_pos.x - object_pos.x) * Mathf.Rad2Deg + 180;
		if (angle % 60 > 30)
			angle += 60;
		angle -= angle % 60;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

	}
}