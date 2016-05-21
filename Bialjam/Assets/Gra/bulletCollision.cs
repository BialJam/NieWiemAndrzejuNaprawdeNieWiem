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
        Debug.Log("colizja");
        if( coll.gameObject.name == "Player 1")
            DestroyObject(gameObject);
    }
}
