using   UnityEngine;
using   System.Collections;
using   System.Collections.Generic;

/*
**  the IEntity interface provide the basics for mobs, npc and the player
*/
public  abstract class  Entity: MonoBehaviour   {

    //  mechanical
    public  string          entityName;
    public  SpriteRenderer  spriteRenderer;
    public  Animator        animator;
    public  Rigidbody2D     rigidBody;
    public  BoxCollider2D   boxCollider;

    //  ressources
    public  int currentHealth;
    public  int maxHealth;
    public  int currentMana;
    public  int maxMana;
    public  int currentStamina;
    public  int maxStamina;

    //  primary stats
    public  int strength;
    public  int vitality;
    public  int agility;
    public  int intelligence;
    public  int luck;

    //  battle stats
    public  int defPhy;
    public  int defMag;
    public  int attPhy;
    public  int attMag;

    //  different state for battles or other interactions
    public  int state;

    //  equivalent to aggroRange for the ennemies
    public  float   sight;

    //  various variables for acceleration/maxSpeed etc...
    public  float   initialSpeed;
    public  float   acceleration;
    public  float   maxSpeed;

    //  functions
    public  abstract void    movement();
    public  abstract void    attack();

}
