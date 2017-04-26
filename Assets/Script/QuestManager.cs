using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using Fungus;
using UnityEngine.SceneManagement;


// ETAPES DE CREATION DE QUETE
//
// 1. CREER FONCTION DE DEPART (EX: INSTANCIER X MOBS)
// 2. CREER FONCTION DE FIN (CHECK LA CONDITION DE FIN DE QUETE)
// 3. AJOUTER CES FONCTIONS A L'INITIALISATION DES LISTES (initActionList & initEndQuestList)
// 4. EN PARALLELE, UTILISER L'EXTENSION FUNGUS (FLOWCHART) POUR CREER DIALOGUES
//    ET GERER INTERACTIONS AVEC PNJs
//
// VOILA ! (PLUS OU MOINS...)

public class QuestManager : MonoBehaviour {

	public enum QuestState {
		UNCOMPLETE, STARTED, COMPLETE, END
	}

	public int currentQuestID;
	private QuestState currentQuestState;
	public bool questEnabled;
	private List<Quest> questList = new List<Quest> ();
	private List<Action> actionList = new List<Action> ();
	private List<Action> questEndList = new List<Action> ();
	public GameObject mobs;
	Inventory inv;


	public int getCurrentQuestID {
		get {
			return currentQuestID;
		}
	}

	public QuestState getCurrentQuestState{
		get {
			return currentQuestState;
		}
	}

	public void setCurrentQuestState (QuestState state){
		currentQuestState = state;
	}

	public List<Quest> getQuestList {
		get {
			return questList;
		}
	}

	public Quest getQuest(int id) {
			var quest = questList.Find( x => x.getID == id );
			return quest;
	}

	// Use this for initialization
	void Start () {
		//currentQuestID = 0;
		currentQuestState = QuestState.UNCOMPLETE;
		questEnabled = false;

		inv = GameObject.Find ("PlayerInv").GetComponent<PlayerInventory> ().inventory;
		//bool debug = GameObject.Find ("PlayerInv").GetComponent<PlayerInventory> ().inventory.checkItem (1, 2);
		//Debug.Log(debug);
		// Connect to DB, load all the Quests in a List
		Debug.Log ("### QuestManager : Start ###");
		string conn = "URI=file:" + Application.dataPath + "/Database/quest.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "SELECT value,name, description, source, mainQuest " + "FROM Quest";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
		while (reader.Read())
		{
			int id = reader.GetInt32(0);
			string name = reader.GetString(1);
			string description = reader.GetString(2);
			string source = reader.GetString(3);
			int mainQuest = reader.GetInt32(4);

			questList.Add (new Quest (id, name, description, source, mainQuest));

			Debug.Log( "QUEST No "+id+" :  NAME ="+name+" //  DESCRIPTION ="+description+"  //  SOURCE ="+source+"  //  MAIN QUEST ? ="+mainQuest);
		}
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
		initActionList ();
		initQuestEndList ();
	}
	
	// Update is called once per frame
	void Update () {
		if (questEnabled == true) {
			isQuestOver (currentQuestID);
		}
		else
			currentQuestState = QuestState.UNCOMPLETE;
	}



	// FUNCTION THAT LAUNCH THE CURRENT QUEST'S START FUNCTION

	public void launchQuest() {
		actionList [currentQuestID] ();
		questEnabled = true;
		currentQuestState = QuestState.UNCOMPLETE;
	}


	// FUNCTION THAT LAUNCH THE CURRENT QUEST'S END FUNCTION

	int isQuestOver(int id) {
		questEndList [id] ();
		return (0);
	}


	// INIT LISTS WITH START AND END FUNCTIONS

	void initActionList() {
		actionList.Add (() => this.questIntroduction ());
		actionList.Add (() => this.quest2 ());
		actionList.Add (() => this.quest3 ());
		actionList.Add (() => this.quest4 ());
	}

	void initQuestEndList() {
		questEndList.Add (() => this.questEndIntroduction ());
		questEndList.Add (() => this.questEnd2 ());
		questEndList.Add (() => this.questEnd3 ());
		questEndList.Add (() => this.questEnd4 ());
	}
		


	// QUESTS START ACTIONS

	void questIntroduction() {
		Debug.Log ("Quest Introduction Launched");
		for (int i = 0; i < 3; i++)
			mobs = Instantiate (Resources.Load ("Ghost"), new Vector3(12, -1, 0), Quaternion.identity) as GameObject;
	}

	void quest2() {
		Debug.Log ("Quest 2 Launched");
	}

	void quest3() {
		Debug.Log ("Quest 3 Launched");

	}

	void quest4() {
		Debug.Log ("Quest 4 Launched");
		mobs = Instantiate (Resources.Load ("Grimoir"), new Vector3 (12, -1, 0), Quaternion.identity) as GameObject;
		mobs.GetComponent<ItemTrigger> ().itemId = 3; //item = crochet
		mobs.GetComponent<ItemTrigger> ().questID = 3;
	}
		

	// QUESTS END CHECK & ACTIONS

	void questEndIntroduction() {
		if (questEnabled == true && GameObject.FindGameObjectsWithTag ("Mob").Length == 0) {
			Debug.Log ("Introduction completed");
			Flowchart.BroadcastFungusMessage ("questEnd");
			//inv.addItem (1, 1);
			questEnabled = false;
			currentQuestID++;
		}
	}

	void questEnd2() {
		QuestTrigger trigger;
		trigger = FindObjectOfType<QuestTrigger> ();
		if (trigger.completed == true) {
			Debug.Log ("Location trouvée");
			Flowchart.BroadcastFungusMessage ("questEnd");
			//inv.addItem (1, 4);
			questEnabled = false;
			currentQuestID++;
		}
	}

	void questEnd3() {
		if (currentQuestState == QuestState.END) {
			inv.addItem (2, 2);
			questEnabled = false;
			currentQuestID++;
		}
	}

	void questEnd4() {
		bool check = inv.checkItem (3, 1);
		if (currentQuestState == QuestState.END) {
			//inv.addItem (2, 5);
			questEnabled = false;
			currentQuestID++;
		} else if (check == true)
			currentQuestState = QuestState.COMPLETE;
	}
}
