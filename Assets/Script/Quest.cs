using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Quest : IComparable<Quest> {

	private int id;
	private string name;
	private string description;
	private string source;
	private bool isMainQuest;


	public Quest(int _id, string _name, string _description, string _source, int _isMainQuest)
	{
		id = _id;
		name = _name;
		description = _description;
		source = _source;
		isMainQuest = Convert.ToBoolean (_isMainQuest);
	}

	public int CompareTo(Quest other)
	{
		if(other == null)
		{
			return 1;
		}
			
		return id - other.id;
	}


	public int getID {
		get {
			return id;
		}
	}

	public string getName {
		get {
			return name;
		}
	}

	public string getDescription {
		get {
			return description;
		}
	}

	public string getSource {
		get {
			return source;
		}
	}

	public bool getIsMainQuest {
		get {
			return isMainQuest;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
