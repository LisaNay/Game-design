using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

	private QuestManager questManager;

	public int questID;
	public bool completed;

	// Use this for initialization
	void Start () {
		questManager = FindObjectOfType<QuestManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			if (questManager.getCurrentQuestID == questID) {
				completed = true;
			}
		}
	}

}
