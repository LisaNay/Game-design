using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Fungus;

public class dialogPNJ : MonoBehaviour {

	public bool nearby;
	public bool waitButton;
	private QuestManager questManager;
	public NS_Player.P_Mvt player;

	// Use this for initialization
	void Start () {
		questManager = FindObjectOfType<QuestManager> ();
		if (questManager.getQuest (1) != null) {
			Debug.Log (questManager.getQuest (1).getID);
		}
		nearby = false;
		player = FindObjectOfType<NS_Player.P_Mvt>();
		//Debug.Log (currentQuest.getName);
		//Textbox = FindObjectOfType<TextboxManager> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F) && nearby == true)
		{
			canMoveFalse ();
			if (questManager.questEnabled == false && questManager.getCurrentQuestState == QuestManager.QuestState.UNCOMPLETE) {
				switch (questManager.getCurrentQuestID) {
				case 0:
					Flowchart.BroadcastFungusMessage ("veilleurStart");
					break;
				case 1:
					Flowchart.BroadcastFungusMessage ("veilleur2");
					break;
				case 2:
					Flowchart.BroadcastFungusMessage ("veilleur3");
					break;
				case 3:
					Flowchart.BroadcastFungusMessage ("veilleur4");
					break;
				default:
					Flowchart.BroadcastFungusMessage ("veilleurNope");
					break;
					
				}

				//Debug.Log ("Quest activated. Quest Source: "+questManager.getQuest (1).getSource+" // Quest Name : "+questManager.getQuest (1).getName+"");
				//questManager.launchQuest (questManager.getCurrentQuestID);
				//.Log("Quest activated! ID: "+currentQuest.getID+" //  Name: "+currentQuest.getName+"");

			} else if (questManager.questEnabled == true && questManager.getCurrentQuestState == QuestManager.QuestState.COMPLETE) {
				switch (questManager.getCurrentQuestID) {
				case 2:
					Flowchart.BroadcastFungusMessage ("Veilleur 3 End");
					break;
				case 3:
					Flowchart.BroadcastFungusMessage ("Veilleur 4 End");
					break;
				
				}
			} else
				Flowchart.BroadcastFungusMessage ("questActive");
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

	public void canMoveTrue() {
		player.canMove = true;
	}

	public void canMoveFalse() {
		player.canMove = false;
	}
}