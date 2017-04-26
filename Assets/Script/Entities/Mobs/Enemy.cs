using   UnityEngine;
using   System.Collections;
using   System.Collections.Generic;

/*
**  the Enemy class provides the basics for the mobs
**  an Enemy is an Entity with a GOAP AI
*/
public  abstract class   Enemy: Entity, IGOAP {

    //  Update is called once per frame
    public  virtual void    Update() {

        //  regenerate the ressources
        /*if( currentHealth   < maxHealth
        ||  currentMana     < maxMana
        ||  currentStamina  < maxStamina ) {
            Invoke( "passiveRegen", 1.0f );
        }*/

    }

    /*
    **  override this function to fit the needs depending on the entity
    **  so we can have diffent kind of regen rates/speed/etc... also depending
    **  on various condition such as the entity's state or the environnement
    */
    public  abstract void   passiveRegen();

    /*
    **  the world state is useful to set variables affecting the fights
    **  these variables can be anything and can determine the logic
    **  behind the different states of an AI
    */
    public  HashSet< KeyValuePair< string, object >>    getWorldState() {
        HashSet< KeyValuePair< string, object >>    worldData;

        worldData = new HashSet< KeyValuePair< string, object >>();

        //worldData.Add( new KeyValuePair< string, object >( "fire", false ));
        //worldData.Add( new KeyValuePair< string, object >( "gas", false ));

        return( worldData );
    }

    public  abstract HashSet<KeyValuePair< string, object >>    createGoalState();

    public  void    planFound( HashSet< KeyValuePair< string, object >> goal, Queue< GOAPAction > action ) {}

    public  void    planFailed( HashSet< KeyValuePair< string, object >>    failedGoal ) {}

    public  void    planAborted( GOAPAction aborter ) {}

    public  void    actionsFinished() {}

    public  virtual bool    moveAgent( GOAPAction nextAction ) {
        /*
        float dist = Vector3.Distance (transform.position, nextAction.target.transform.position);
        if (dist < aggroDist) {
            Vector3 moveDirection = player.transform.position - transform.position;

            setSpeed (speed);

            if (initialSpeed < terminalSpeed) {
                initialSpeed += acceleration;
            }

            Vector3 newPosition = moveDirection * initialSpeed * Time.deltaTime;
            transform.position += newPosition;
        }
        if(dist <= minDist) {
            nextAction.setInRange(true);
            return true;
        } else {
            return false;
        }
        */
        return( false );
    }
}
