using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class testDatabase : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("### Test database ###");
		string conn = "URI=file:" + Application.dataPath + "/Database/quest.db"; //Path to database.
		IDbConnection dbconn;
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		IDbCommand dbcmd = dbconn.CreateCommand();
		string sqlQuery = "SELECT value,name, description, source, mainQuest " + "FROM Quest";
		dbcmd.CommandText = sqlQuery;
		IDataReader reader = dbcmd.ExecuteReader();
		Debug.Log ("### Juste avant le read ###");
		while (reader.Read())
		{
			int value = reader.GetInt32(0);
			string name = reader.GetString(1);
			string description = reader.GetString(2);
			string source = reader.GetString(3);
			int mainQuest = reader.GetInt32(4);

			Debug.Log( "VALUE= "+value+" //  NAME ="+name+" //  DESCRIPTION ="+description+"  //  SOURCE ="+source+"  //  MAIN QUEST ? ="+mainQuest);
		}
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
