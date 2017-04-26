using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mono.Data.Sqlite;
using System.Data;

public class Inventory : MonoBehaviour {

	/*
	 * Liste des fonctions utiles pour les quêtes :
	 * 
	 * addItem(int _itemID, int _itemQuantity); -> ajoute un nombre precis d'un objet dans l'inventaire.
	 * removeItemPack(int _itemID); -> Supprime tous les objets de l'ID spécifié en paramètre.
	 * removeItemQuantity(int _itemID, int _itemQuantity); -> Supprime un nombre donné d'item dans l'inventaire.
	 * checkItem(int _itemID, int _itemQuantity); -> cherche un nombre donné d'objets dans l'inventaire
	 * (renvoi true si l'inventaire contient au minimum le nombre donné de l'item spécifié en paramètre et false
	 * dans le cas contraire).
	 */

	// Variables utiles
	Dictionary<int, Item> listItems = new Dictionary<int, Item>() {};
	Dictionary<int, Item> inventoryStocks = new Dictionary<int, Item>() {};
	public static Item item;
	private int Key;
	private int keyListItem;
	private int countKey;
	private int searchItemKey;

	// Fonction qui ajoute un item dans l'inventaire
	public void addItem (int _itemID, int _itemQuantity) {
		if (inventoryCheckItem (_itemID) == true) {
			inventoryStocks [searchItemKey].quantity += _itemQuantity;
			Debug.Log("Actualisation d'un item déjà existant");
		}
		else {
			addNewItem (_itemID, _itemQuantity);
		}

		displayInventoryContent();
	}

	// Fonction qui supprime un groupe d'item de l'inventaire
	public void removeItemPack (int _itemID) {
		if (inventoryCheckItem (_itemID) == true) {
			inventoryStocks.Remove (searchItemKey);
			Debug.Log ("Vous venez de supprimer un objet de votre inventaire.");
			displayInventoryContent ();
		} else {
			Debug.Log ("Il n'y a rien à supprimer ici.");
		}
	}

	// Fonction qui supprime un nombre donné d'un type d'item
	public void removeItemQuantity(int _itemID, int _itemQuantity) {
		if (inventoryCheckItem (_itemID) == true) {
			if (inventoryStocks [searchItemKey].quantity > _itemQuantity) {
				inventoryStocks [searchItemKey].quantity -= _itemQuantity;
			} else {
				inventoryStocks.Remove (searchItemKey);
			}
			Debug.Log ("Vous venez de supprimer un objet de votre inventaire.");
			displayInventoryContent ();
		} else {
			Debug.Log ("Il n'y a rien à supprimer ici.");
		}
	}

	// Fonction qui check si l'inventaire contient le nombre donné d'un item précis
	public bool checkItem (int _itemID, int _itemQuantity) {
		foreach (KeyValuePair<int, Item> inventoryStock in inventoryStocks) {
			if ((inventoryStock.Value.ID == _itemID) &&
				(inventoryStock.Value.quantity >= _itemQuantity)) {
				Debug.Log ("Ouais c'est bon y'en a assez.");
				return (true);
			}
		}
		Debug.Log ("Nan c'est mort, y'en a pas assez.");
		return (false);
	}

	/* Fonction qui parcours l'inventaire et renvoi true s'il contient le type d'item cherché
	 * et stock la key de l'item cherché
	 */
	private bool inventoryCheckItem (int _itemID) {
		foreach (KeyValuePair<int, Item> inventoryStock in inventoryStocks) {
			if (inventoryStock.Value.ID == _itemID) {
				searchItemKey = inventoryStock.Key;
				return (true);
			}
		}

		return (false);
	}

	// Fonction qui ajoute un nouvel item dans l'inventaire
	private void addNewItem (int _itemID, int _itemNumber) {
		foreach (KeyValuePair<int, Item> listItem in listItems) {
			if (listItem.Value.ID == _itemID) {
				item = gameObject.AddComponent<Item> ();
				item.ID = listItem.Value.ID;
				item.itemName = listItem.Value.itemName;
				item.quantity = listItem.Value.quantity;
				item.description = listItem.Value.description;
				item.usable = listItem.Value.usable;
				inventoryStocks.Add (countKey, item);
				Debug.Log("Ajout d'un nouvel item dans l'inventaire");
				countKey++;
				return;
			}
		}
		Debug.Log ("Aucun objet de la liste globale des objets du jeu ne possède cet ID.");
	}

	private void createItemList () {
		string pathDB;
		IDbConnection dbconn;
		IDbCommand dbcmd;
		string sqlQuery;

		pathDB = "URI=file:" + Application.dataPath + "/Database/ShanDB.db";
		dbconn = (IDbConnection) new SqliteConnection (pathDB);
		dbcmd = dbconn.CreateCommand ();
		sqlQuery = "SELECT value,name,quantity,description,usable FROM Item";
		dbcmd.CommandText = sqlQuery;

		// Connexion à la base de données et lecture du résultat de la requête
		dbconn.Open ();
		IDataReader reader = dbcmd.ExecuteReader ();
		while (reader.Read ()) {
			int _id = reader.GetInt32(0);
			string _itemName = reader.GetString (1);
			int _quantity = reader.GetInt32 (2);
			string _description = reader.GetString (3);
			int _usable = reader.GetInt32 (4);

			// Création du nouvel Itemm
			item = gameObject.AddComponent<Item>();
			item.ID = _id;
			item.itemName = _itemName;
			item.quantity = _quantity;
			item.description = _description;
			item.usable = Convert.ToBoolean (_usable);

			// Ajout du nouvel Item dans le dictionnaire
			listItems.Add (keyListItem, item);
			keyListItem++;
		}
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;

		displayListContent ();
	}

	// Use this for initialization
	void Start () {
		// Variables utiles
		countKey = 0;
		keyListItem = 0;
		searchItemKey = 0;

		//Création de la liste qui contient tous les items du jeu
		createItemList ();
	}

	// Update is called once per frame
	void Update () {
		// Fonctions de test
		testAddItem ();
		testRemoveItem ();
		testCheckItem ();
		testRemoveItemQuantity ();
	}

	/*
	 * ATTENTION !
	 * Les fonctions qui suivront seront uniquement des fonctions de tests
	 * 
	 */

	// Fonction qui ajoute un nouvel objet dans l'inventaire chaque fois que l'on appui sur les touches F?
	private void testAddItem() {
		if (Input.GetKeyDown(KeyCode.F1))
			addItem(1, 1);
		if (Input.GetKeyDown(KeyCode.F2))
			addItem(2, 1);
		if (Input.GetKeyDown(KeyCode.F3))
			addItem(3, 1);
		if (Input.GetKeyDown(KeyCode.F4))
			addItem(42, 1);
	}

	// Fonction qui supprime un item donné quand on appui sur I
	private void testRemoveItem() {
		if (Input.GetKeyDown (KeyCode.I)) {
			removeItemPack (1);
		}
	}

	// Fonction qui supprime un nombre donné d'un pack d'item donné quand on appui sur O
	private void testRemoveItemQuantity() {
		if (Input.GetKeyDown (KeyCode.O)) {
			removeItemQuantity (1, 2);
		}
	}

	// Fonction qui check le nombre donné d'un type d'item quand on appui sur P
	private void testCheckItem() {
		if (Input.GetKeyDown (KeyCode.P)) {
			checkItem (1, 2);
		}
	}

	// Fonction de test qui affiche le contenu de l'inventaire
	private void displayInventoryContent() {
		foreach(KeyValuePair<int, Item> inventoryStock in inventoryStocks)
		{
			Debug.Log("A l'emplacement : " + inventoryStock.Key + " l'inventaire contient "
				+ inventoryStock.Value.quantity + " " + inventoryStock.Value.itemName + ".");
		}
	}

	// Fonction de test qui affiche le contenu de la liste d'objet
	private void displayListContent() {
		foreach(KeyValuePair<int, Item> listItem in listItems)
		{
			Debug.Log("ID : " + listItem.Value.ID + ", Name : " + listItem.Value.itemName
				+ ", Quantity : " + listItem.Value.quantity + ", Description : " + listItem.Value.description
				+ ", Usable : " + listItem.Value.usable + ".");
		}
	}

}