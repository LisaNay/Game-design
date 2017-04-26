using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour {

	private QuestManager questManager;
	public int questID { get; set; }
	public int itemId { get; set; }
	bool nearby;
	Inventory i;

	// Use this for initialization
	void Start () {
		questManager = FindObjectOfType<QuestManager> ();
		nearby = false;
		i = GameObject.Find ("PlayerInv").GetComponent<PlayerInventory> ().inventory;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (questManager.getCurrentQuestID == questID && Input.GetKeyDown (KeyCode.F ) && nearby == true) {
			i.addItem (itemId, 1);
			Destroy (gameObject);
		}
		
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			nearby = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			nearby = false;
		}
	}
}
