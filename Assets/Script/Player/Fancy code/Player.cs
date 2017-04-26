using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Player{

	public class Player : MonoBehaviour{

		[HideInInspector]
		public int RIGHT		= 0;
		[HideInInspector]
		public int DOWN			= 1;
		[HideInInspector]
		public int LEFT			= 2;
		[HideInInspector]
		public int UP			= 3;
		[HideInInspector]
		public int Direction	= 1;
		[HideInInspector]
		public bool IsDashing	= false;
		[HideInInspector]
		public Rigidbody2D myRigidbody;


		//private movement myMovement;

		// Use this for initialization
		void Start () {
			myRigidbody = GetComponent<Rigidbody2D> ();
			//myMovement = GetComponent<movement> ();
			//int direction = facing.Right;
			//Debug.Log("Direction = " + Direction );
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
}
