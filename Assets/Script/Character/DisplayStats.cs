using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour {

	private BaseHero class1 = new BaseHero();

	Text txt;

	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<Text>(); 
		txt.text = (": " + class1.strength.ToString ()) + "\n" + (": " + class1.vitality.ToString ())
		+ "\n" + (": " + class1.agility.ToString ()) + "\n" + (": " + class1.intelligence.ToString ())
		+ "\n" + (": " + class1.luck.ToString ());
	}
		
}