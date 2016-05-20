using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.Find ("Me");
		transform.LookAt (target.transform);
		transform.Rotate (Vector3.up * 90);

	}
}
