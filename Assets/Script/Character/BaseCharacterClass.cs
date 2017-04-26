using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass {

    // Stats Description
    private string _strengthDescription;
    private string _vitalityDescription;
    private string _agilityDescription;
    private string _intelligenceDescription;
    private string _luckDescription;

    // Stats
    private int _strength;
    private int _vitality;
    private int _agility;
    private int _intelligence;
    private int _luck;

    // others
    private int _level;

    // functions
    public string strengthDescription {get;set;}
    public string vitalityDescription {get;set;}
    public string agilityDescription {get;set;}
    public string intelligenceDescription {get;set;}
    public string luckDescription {get;set;}

    public int strength {get;set;}
    public int vitality {get;set;}
    public int agility {get;set;}
    public int intelligence {get;set;}
    public int luck {get;set;}
    public int level {get;set;}

}
