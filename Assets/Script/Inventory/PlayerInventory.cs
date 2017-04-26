using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	public Inventory inventory;

	// Use this for initialization
	void Start () {
		inventory = FindObjectOfType<Inventory> ();
		inventory.addItem (1, 1);
		inventory.addItem (1, 1);
		inventory.addItem (2, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
