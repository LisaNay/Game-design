using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour {
	LevelSystem levelSystem;

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Player") {
			levelSystem.addFragment(1);

			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		levelSystem = GameObject.Find ("PlayerLevelSystem").GetComponent<PlayerLevelSystem> ().levelSystem;
	}

	// Update is called once per frame
	void Update () {

	}
}
