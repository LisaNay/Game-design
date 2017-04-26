using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHero : BaseCharacterClass {

	public BaseHero() {
		strengthDescription = "It affects the physical (melee) power of the hero and it's capacity to move objects.";
		vitalityDescription = "It affects the endurance, HP, etc..";
		agilityDescription = "It affects the hero capacity to avoid attack, dash, etc..";
		intelligenceDescription = "It affects the damage the hero can deal with spells as well as his capacity to interract with people and objects.";
		luckDescription = "It affects the fortune of the hero in some aspects, allowing it to deal Critical hits more often among several other bonuses.";

		level = 1;
		strength = 12;
		vitality = 15;
		agility = 11;
		intelligence = 13;
		luck = 5;
	}		

}
