using UnityEngine;
using System.Collections;

public class EntityMovement : MonoBehaviour {
/*
	private BoxCollider2D boxCollider;
	private Animator animator;
	private Rigidbody2D rigidBody;
	private SpriteRenderer spriteRenderer;
	private Vector3 moveDirection;

	private float initialSpeed = this.initialSpeed;
	private float acceleration = this.acceleration;
	private float maxSpeed = this.maxSpeed;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		boxCollider = GetComponent <BoxCollider2D> ();
		rigidBody = GetComponent <Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		moveDirection = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0);
		if (initialSpeed < maxSpeed) {
			initialSpeed += acceleration;
		}
		Vector3 newPosition = moveDirection * initialSpeed * Time.deltaTime;
		transform.position += newPosition;
	}
*/
}
