using UnityEngine;
using System.Collections;

public class LightManager {
	Material LightOnMaterial;
	Material LightOffMaterial;
	public bool IsOn = true;
	// Use this for initialization
	public void UpdateLights() {
		GameObject[] allLights = GameObject.FindGameObjectsWithTag ("Light");

		foreach (GameObject i in allLights) {
			i.SetActive (IsOn);
		} 
		SpriteRenderer[] bitmaps = GameObject.FindObjectsOfType<SpriteRenderer>();
		if (IsOn) {
			foreach (SpriteRenderer i in bitmaps) {
				i.material = LightOnMaterial;
			} 
		} else {
			foreach (SpriteRenderer i in bitmaps) {
				i.material = LightOffMaterial;
			} 
		}
	}

	public void SetLights(bool enabled) {
		IsOn = enabled;
		UpdateLights ();
	}

	private static LightManager instance;
	public static LightManager Instance
	{
		get
		{
			if(instance==null)
			{
				instance = new LightManager();
				instance.LightOnMaterial = Resources.Load("Materials/LightOnMaterial", typeof(Material)) as Material;
				instance.LightOffMaterial = Resources.Load("Materials/LightOffMaterial", typeof(Material)) as Material;
			}
			return instance;
		}
	}
}
