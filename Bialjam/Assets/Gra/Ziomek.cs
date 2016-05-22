using UnityEngine;
using System.Collections;

public class Ziomek : MonoBehaviour {
	public GameObject Aura;
	private float nextRandom = 0.0f;
	public bool aura;
	private float usunAure = 999999999;
	public float auraExhaust = 10f;
	// Use this for initialization
	void Start () {
		Aura.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if ((double)Time.time > nextRandom ) {
			if (Random.Range (0, 100) >= 80) {
				aura = true;
				usunAure = Time.time + auraExhaust;
				Aura.SetActive(true);
			}
			nextRandom = Time.time + Random.Range(1.5f, 2.5f);
		}
		if (aura && (double)Time.time > usunAure) {
			usunAure = 999999999;
			aura = false;
			Aura.SetActive (false);
		}
	}
	void OnDamage(){
		if (!aura) {
			Destroy (gameObject);
			Buttons.LosedGame ();
		}
	}
}
