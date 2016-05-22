using UnityEngine;
using System.Collections;

public class LightManager {
	Material LightOnMaterial;
	Material LightOffMaterial;
	public bool IsOn = true;
	// Use this for initialization
	public void UpdateLights() {
		bool lightOn = IsOn;
		if (!Application.loadedLevelName.StartsWith ("Level"))
			lightOn = false;
		
		GameObject[] allLights = GameObject.FindGameObjectsWithTag ("Light");

		foreach (GameObject i in allLights) {
			i.SetActive (lightOn);
		} 
		SpriteRenderer[] bitmaps = GameObject.FindObjectsOfType<SpriteRenderer>();
		if (lightOn) {
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
