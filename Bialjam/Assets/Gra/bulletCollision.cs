using UnityEngine;
using System.Collections;

public class bulletCollision : MonoBehaviour {
    
    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
		if (coll.gameObject && coll.gameObject.layer == 10) { // Player's layer
			DestroyObject (gameObject);
		}
    }
}
