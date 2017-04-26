using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {
	//LevelSystem levelSystem;
	Inventory i;

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Player") {
			//levelSystem.addFragment(1);
			i.addItem(1, 5);

			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		i = GameObject.Find ("PlayerInv").GetComponent<PlayerInventory> ().inventory;
		//levelSystem = GameObject.Find ("PlayerLevelSystem").GetComponent<PlayerLevelSystem> ().levelSystem;
	}

	// Update is called once per frame
	void Update () {

	}
}
