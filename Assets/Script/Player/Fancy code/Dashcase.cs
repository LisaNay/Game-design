using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Player{
	
	public class Dashcase : MonoBehaviour {

		[SerializeField]
		private float DashForce = 5;
		private float DashDuration = 1;
		[SerializeField]
		private float DashCooldown = 3;
		private float DashTimer = 0;
		private Player myPlayer;
		private DashState dashState;
		private enum DashState 
		{
			Ready,
			Dashing,
			Cooldown
		}


		// Use this for initialization
		void Start () {
			myPlayer = GetComponent<Player> ();
		}
		
		// Update is called once per frame
		void Update () {

			switch (dashState)
			{
			case DashState.Ready:
				if ((Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) && Input.GetKeyDown (KeyCode.Space))
				{
					myPlayer.IsDashing = true;
					dashState = DashState.Dashing;
					myPlayer.myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * DashForce, myPlayer.myRigidbody.velocity.y);
				}
				if ((Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) && Input.GetKeyDown (KeyCode.Space))
				{
					myPlayer.IsDashing = true;
					dashState = DashState.Dashing;
					myPlayer.myRigidbody.velocity = new Vector2 (myPlayer.myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * DashForce);
				}
				break;
			case DashState.Dashing:
				DashTimer += 0.1f;
				if (DashTimer >= DashDuration) 
				{
					DashTimer = 0;
					myPlayer.IsDashing = false;
					dashState = DashState.Cooldown;
					myPlayer.myRigidbody.velocity = new Vector2 (0f, myPlayer.myRigidbody.velocity.y);
					myPlayer.myRigidbody.velocity = new Vector2 (myPlayer.myRigidbody.velocity.x, 0f);
				}
				break;
			case DashState.Cooldown:
				DashTimer += 0.1f;
				if (DashTimer >= DashCooldown)
				{
					DashTimer = 0;
					dashState = DashState.Ready;
				}
				break;
			}
		}
	}
}