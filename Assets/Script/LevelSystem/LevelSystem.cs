using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour {
	private int dust;
	private int fragment;
	private int crystal;

	private int maxDust;
	private int maxFragment;

	// Getter de crystal (la variable crystal équivaut au niveau du joueur)
	public int getCrystal {
		get {
			return crystal;
		}
	}

	// Fonction permettant d'ajouter du dust
	public void addDust(int _dustQuantity) {
		if (_dustQuantity >= maxDust) {
			Debug.Log ("[LevelSystem] Error : Il est impossible d'ajouter plus de " + (maxDust - 1)
				+ " dust d'un seul coup.");
			return;
		}
		if ((dust + _dustQuantity) >= maxDust) {
			resetDust (_dustQuantity);
			addFragment(1);
		} else {
			dust += _dustQuantity;
			Debug.Log (_dustQuantity + " poussières ont été ajoutées, total de dust : " + dust + ".");
		}
	}

	// Fonction permettant d'ajouter un ou plusieurs fragments
	public void addFragment(int _fragmentQuantity) {
		if (_fragmentQuantity >= maxFragment) {
			Debug.Log ("[LevelSystem] Error : Il est impossible d'ajouter plus de " + (maxFragment - 1)
				+ " fragments d'un seul coup.");
			return;
		}
		if ((fragment + _fragmentQuantity) >= maxFragment) {
			resetFragment (_fragmentQuantity);
			addCrystal(1);
		} else {
			fragment += _fragmentQuantity;
			Debug.Log ("Total de fragments : " + fragment + ".");
		}
	}

	// Fonction permettant d'ajouter un crystal
	public void addCrystal(int _crystalQuantity) {
		crystal += _crystalQuantity;
		Debug.Log ("Total de cristaux : " + crystal + ".");
		addStatPoint ();
		if ((crystal % 5) == 0) {
			addCompPoint ();
		}
	}

	// Cette fonction re set la variable dust à zéro
	private void resetDust(int _dustQuantity) {
		dust = (dust + _dustQuantity) - maxDust;
		Debug.Log ("La dust a été set à " + dust + ".");
	}

	// Cette fonction permet de re set fragment à zéro
	private void resetFragment(int _fragmentQuantity) {
		fragment = (fragment + _fragmentQuantity) - maxFragment;
		Debug.Log ("Les fragments ont été set à " + fragment + ".");
	}

	// Ajoute un ou plusieurs points de statistiques
	private void addStatPoint() {
		//Ajouter un point de statistique, ou plusieurs dans la classe de gestion de statistiques
		Debug.Log("[Non implémentée] Points de statistiques ajoutés.");
	}

	// Ajoute un point de compétence
	private void addCompPoint() {
		//Ajouter un point de compétences dans la classe de gestion de compétences
		Debug.Log("[Non implémentée] Point de compétence ajouté.");
	}

	// Use this for initialization
	void Start () {
		maxDust = 500;
		maxFragment = 4;
	}
	
	// Update is called once per frame
	void Update () {
		// Fonctions de test
		testAddXP ();
		testAddCrystal ();
	}

	/*
	 * ATTENTION !
	 * Les fonctions qui suivront seront uniquement des fonctions de tests 
	 * 
	 */

	// Fonction qui ajoute de la dust
	private void testAddXP() {
		if (Input.GetKeyDown(KeyCode.KeypadPlus))
			addDust(110);
	}

	// Fonction qui ajoute un crystal
	private void testAddCrystal() {
		if (Input.GetKeyDown(KeyCode.Keypad1))
			addCrystal(1);
	}
}
