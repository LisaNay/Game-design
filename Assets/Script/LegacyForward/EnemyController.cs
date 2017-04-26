using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D myRigidbody;

	public float moveSpeed;
	private bool moving;

	public float timeBetweenMove;
	private float timeBetweenMoveCounter;

	public float timeToMove;
	private float timeToMoveCounter;

	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody2D> ();

		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.5f, timeBetweenMove * 1.0f);
		timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
	
	}
	
	// Update is called once per frame
	void Update () {
	
		/*
		** MOVEMENTS
		*/
		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;
			if (timeToMoveCounter < 0f) {
				moving = false;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.5f, timeBetweenMove * 1.0f);
			}
		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			if (timeBetweenMoveCounter < 0f) {
				moving = true;
				timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
				moveDirection = new Vector3 (Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
			}
		}
	
	}

}
