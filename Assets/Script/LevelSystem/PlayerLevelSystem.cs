using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSystem : MonoBehaviour {
	
	public LevelSystem levelSystem;

	// Use this for initialization
	void Start () {
		levelSystem = FindObjectOfType<LevelSystem> ();
		levelSystem.addCrystal (1);
		levelSystem.addCrystal (1);
		levelSystem.addCrystal (1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
