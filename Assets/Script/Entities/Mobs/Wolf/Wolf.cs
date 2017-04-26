using   UnityEngine;
using   System.Collections;
using   System.Collections.Generic;

public  class   Wolf:   Enemy   {

	// Use this for initialization
	void Start () {

	}

	public override void passiveRegen(){
		//stamina += regenRate;
	}

	public override HashSet<KeyValuePair<string, object>> createGoalState(){
		HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>> ();
		goal.Add (new KeyValuePair<string, object> ("damagePlayer", true));
		goal.Add (new KeyValuePair<string, object> ("stayAlive", true));
		return goal;
	}

    public  override void   movement() {}
    public  override void   attack() {}
}
