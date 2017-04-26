using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Pnj2 : MonoBehaviour {

	private QuestManager questManager;
	public bool nearby;

	// Use this for initialization
	void Start () {
		questManager = FindObjectOfType<QuestManager> ();
		nearby = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F) && nearby == true) {
			if (questManager.questEnabled == true && questManager.getCurrentQuestState == QuestManager.QuestState.UNCOMPLETE) {
				switch (questManager.getCurrentQuestID) {
				case 2:
					Flowchart.BroadcastFungusMessage ("Boucher start");
					break;
				default:
					Flowchart.BroadcastFungusMessage ("Boucher busy");
					break;
				}
			} else 
				Flowchart.BroadcastFungusMessage ("Boucher busy");
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
			nearby = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
			nearby = false;
	}
}
