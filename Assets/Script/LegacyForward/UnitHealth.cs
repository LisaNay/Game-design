using UnityEngine;
using System.Collections;

public class UnitHealth : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;
	public AudioClip dead;

	// Use this for initialization
	void Start () {

		CurrentHealth = MaxHealth;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (CurrentHealth <= 0) {
			gameObject.SetActive (false);
		}

	}

	public void RestoreMaxHealth () {

		CurrentHealth = MaxHealth;

	}

}