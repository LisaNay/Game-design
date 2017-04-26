using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	public Transform target;
	public float speed = 1f;
	Camera mycam;

	// Use this for initialization
	void Start () {

		mycam = GetComponent<Camera> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		mycam.orthographicSize = (Screen.height / 100f)/8f;

		if (target) {

			transform.position = Vector3.Lerp (transform.position, target.position, speed) + new Vector3(0, 0, -10);

		}
	
	}
}
