using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float moveSpeed = 2f;

	private float CurrentSpeed;

	private Rigidbody2D myRigidbody;


	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		// permet de trouver l'objet dans d'autres scenes
		//DontDestroyOnLoad (transform.gameObject);
	}

	// Update is called once per frame
	void Update () {


		if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
			CurrentSpeed = moveSpeed / 1.3f;
		} else {
			CurrentSpeed = moveSpeed;
		}

		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) 
		{
			//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * CurrentSpeed * Time.deltaTime, 0f, 0f));
			myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * CurrentSpeed, myRigidbody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) 
		{
			//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * CurrentSpeed * Time.deltaTime, 0f));
			myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * CurrentSpeed);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) 
		{
			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) 
		{
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
		}
	}
}