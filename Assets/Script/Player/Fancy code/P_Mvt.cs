using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Player{
	
	public class P_Mvt : MonoBehaviour {

		[SerializeField]
		private float moveSpeed =1.5f;	// Vitesse de deplacement initial.
		private float CurrentSpeed;		// Vitesse de deplacement reelle.
		private Player myPlayer;
		public bool canMove = true;

		// Use this for initialization
		void Start () 
		{
			myPlayer = GetComponent<Player> ();
		}
	

		// Update is called once per frame
		void Update () 
		{
			if (myPlayer.IsDashing == false && canMove == true)
			{
				Movement ();
				Facing ();
			}
		}

		// Fonction qui gere le mouvement.
		private void Movement()
		{
			// Baisse de la vitesse du joueur en cas de deplacement en diagonal (sinon cummulation vitesse vertical + horizontal).
			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f)
				CurrentSpeed = moveSpeed / 1.3f;
			else
				CurrentSpeed = moveSpeed;

			// Deplace le joueur s'il appuie sur haut ou bas .
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
				myPlayer.myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * CurrentSpeed, myPlayer.myRigidbody.velocity.y);

			// Deplace le joueur s'il appuie sur droite ou gauche.
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
				myPlayer.myRigidbody.velocity = new Vector2(myPlayer.myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * CurrentSpeed);

			// Arrete le deplacement du joueur quand il cesse d'appuier.
			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f)
				myPlayer.myRigidbody.velocity = new Vector2 (0f, myPlayer.myRigidbody.velocity.y);

			// Arrete le deplacement du joueur quand il cesse d'appuier.
			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f)
				myPlayer.myRigidbody.velocity = new Vector2 (myPlayer.myRigidbody.velocity.x, 0f);
		}

		private void Facing ()
		{
			if (Input.GetAxisRaw ("Horizontal") > 0.5f)
				myPlayer.Direction = myPlayer.RIGHT;
			if (Input.GetAxisRaw ("Horizontal") < -0.5f)
				myPlayer.Direction = myPlayer.LEFT;
			if (Input.GetAxisRaw ("Vertical") > 0.5f)
				myPlayer.Direction = myPlayer.UP;
			if (Input.GetAxisRaw ("Vertical") < -0.5f)
				myPlayer.Direction = myPlayer.DOWN;
		}
	}
}
