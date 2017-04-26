using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Player{

	public class Dash : MonoBehaviour {

		[SerializeField]
		private float DashForce = 5;
		private float DashDuration = 1;
		private float DashCooldown = 0;
		private Player myPlayer;

		// Use this for initialization
		void Start () {
			myPlayer = GetComponent<Player> ();
		}

		// Update is called once per frame
		void Update () {
			if (DashCooldown <= 0) {
				if ((Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) && Input.GetKeyDown (KeyCode.Space))
				{
					myPlayer.IsDashing = true;
					myPlayer.myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * DashForce, myPlayer.myRigidbody.velocity.y);
					DashDuration = 1;
					DashCooldown = 20;
				}
				if ((Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) && Input.GetKeyDown (KeyCode.Space))
				{
					myPlayer.IsDashing = true;
					myPlayer.myRigidbody.velocity = new Vector2 (myPlayer.myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * DashForce);
					DashDuration = 1;
					DashCooldown = 20;
				}
			}

			if (DashDuration > 0)
			{

				DashDuration -= 0.1f;
			}
			if (DashDuration <= 0 )
			{
				myPlayer.myRigidbody.velocity = new Vector2 (0f, myPlayer.myRigidbody.velocity.y);
				myPlayer.myRigidbody.velocity = new Vector2 (myPlayer.myRigidbody.velocity.x, 0f);
				myPlayer.IsDashing = false;
			}
			if (DashCooldown > 0)
			{
					
				DashCooldown -= 0.1f;
			}
		}
	}
}