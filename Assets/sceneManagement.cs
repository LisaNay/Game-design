using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagement : MonoBehaviour {

	AsyncOperation async;

	// Use this for initialization
	void Start () {
		
		SceneManager.LoadScene ("Scenes/Scenes_Test/UI", LoadSceneMode.Additive);
		SceneManager.LoadScene ("Scenes/Scenes_Test/LevelSystem", LoadSceneMode.Additive);
		SceneManager.LoadScene ("Scenes/Scenes_Test/layers", LoadSceneMode.Additive);
		SceneManager.LoadScene ("Scenes/Scenes_Test/inventory", LoadSceneMode.Additive);
		SceneManager.LoadScene ("Scenes/Scenes_Test/IA", LoadSceneMode.Additive);
		SceneManager.LoadScene ("Scenes/Scenes_Test/quetes", LoadSceneMode.Additive);
		SceneManager.LoadScene ("Scenes/Scenes_Test/player", LoadSceneMode.Additive);
		Debug.Log ("Scenes loaded : " + SceneManager.sceneCount);


	}
	
	// Update is called once per frame
	void Update () {		
	}
}
