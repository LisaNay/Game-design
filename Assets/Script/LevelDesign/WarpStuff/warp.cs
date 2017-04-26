using UnityEngine;
using System.Collections;

public class warp : MonoBehaviour {

	public Transform warpTarget;

	IEnumerator OnTriggerEnter2D(Collider2D other) {

		Debug.Log ("An object collided");

		//Screen fader
		ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

		Debug.Log ("Pre fade out");

		//Tentative de pause
		//Time.timeScale = 0f;

		//Première animation du fondu d'écran
		yield return StartCoroutine (sf.FadeToBlack ());

		//Le joueur se déplace jusqu'à la nouvelle cible
		Debug.Log ("Update player position");

		if (other.gameObject.tag == "Player") {
			other.gameObject.transform.position = warpTarget.position;
			Camera.main.transform.position = warpTarget.position;
		}

		//Dernière animation du fondu d'écran
		yield return StartCoroutine (sf.FadeToClear ());

		//Tentative de dépausage
		//Time.timeScale = 1f;

		Debug.Log ("Fade in complete");

	}
}
