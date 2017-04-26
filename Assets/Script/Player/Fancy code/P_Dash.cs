using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Dash : MonoBehaviour {
	/*
	 Dash dispo 1/0

	reload time 1f

	timeToMoveCounter -= Time.deltaTime;
	public float timeBetweenMove;

	*/

	public float reload_time = 0;
	public float DashSpeed = 5;
	public float DashTime = 1;
	//public bool Dashing = false;
	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (reload_time <= 0) {
			
			if ((Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) && Input.GetKeyDown (KeyCode.Space)) 
			{
				myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * DashSpeed, myRigidbody.velocity.y);
				DashTime = 0;
				reload_time = 1.5f;
			}

			if ((Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) && Input.GetKeyDown (KeyCode.Space)) 
			{
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * DashSpeed);
				DashTime = 0;
				reload_time = 1.5f;
			}

		}
		else if (reload_time > 0) {
			reload_time -= Time.deltaTime;
		}

		/*if (DashTime > 0 && DashTime <= 1)
			DashTime = Dash_duration (DashTime);*/
		if (DashTime < 1)
			DashTime += Time.deltaTime;
		if (DashTime >= 1) 
		{
			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
			//Dashing = false;
		}

		/*if (DashTime >= 1) 
		{
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
			DashTime = 1;
		}*/


	}
	/*float Dash_duration(float DashTime)
	{
		DashTime -= Time.deltaTime;
		return (DashTime);
	}*/
}
