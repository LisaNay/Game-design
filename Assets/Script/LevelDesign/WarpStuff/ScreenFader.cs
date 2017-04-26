using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

	Animator anim;
	bool isFading = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		
	}

	public IEnumerator FadeToClear() {
		isFading = true;
		//Jeu en pause pendant le fade in
		Time.timeScale = 0;
		anim.SetTrigger ("FadeIn");

		while (isFading)
			yield return null;
	}

	public IEnumerator FadeToBlack() {
		isFading = true;
		//Jeu en pause pendant le fade in
		Time.timeScale = 0;
		anim.SetTrigger ("FadeOut");

		while (isFading)
			yield return null;
	}
	
	void AnimationComplete() {
		isFading = false;
		//Le jeu quitte la pause à la fin du fade in
		Time.timeScale = 1;
	}
}
