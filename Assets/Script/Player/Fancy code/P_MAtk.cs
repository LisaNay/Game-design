using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS_Player{

	public class P_MAtk : MonoBehaviour {

		public EdgeCollider2D Right_Atk;
		public EdgeCollider2D Down_Atk;
		public EdgeCollider2D Left_Atk;
		public EdgeCollider2D Up_Atk;
		private Player myPlayer;

		void Start () {
			myPlayer = GetComponent<Player> ();
		}

		void Update () {
			Handle_Matk ();
		}

		private void Handle_Matk()
		{
			if (Input.GetMouseButtonDown (0) && myPlayer.Direction == myPlayer.RIGHT)
				Right_Atk.enabled = true;
			if (Input.GetMouseButtonDown (0) && myPlayer.Direction == myPlayer.DOWN)
				Down_Atk.enabled = true;
			if (Input.GetMouseButtonDown (0) && myPlayer.Direction == myPlayer.LEFT)
				Left_Atk.enabled = true;
			if (Input.GetMouseButtonDown (0) && myPlayer.Direction == myPlayer.UP)
				Up_Atk.enabled = true;
			if (Input.GetMouseButtonUp (0))
			{
				Right_Atk.enabled	= false;
				Down_Atk.enabled	= false;
				Left_Atk.enabled	= false;
				Up_Atk.enabled		= false;
			}
		}
	}
}
