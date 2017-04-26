using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	public int damage;
	public GameObject damageParticule;
	private Object clonedParticule;
	private float timeToDestroy;
	public AudioClip Monsterdamaged;
	public AudioClip Playerdamaged, Playerdamaged2;

	// Use this for initialization
	void Start () {
		timeToDestroy = 1f;
	}

	// Update is called once per frame
	void Update () {
		timeToDestroy -= Time.deltaTime;
		if (timeToDestroy <= 0f) {
			Destroy(clonedParticule);
			timeToDestroy = 1f;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<UnitHealth> ().CurrentHealth -= damage;
			clonedParticule = Instantiate (damageParticule, transform.position, transform.rotation);
			timeToDestroy = 1f;
		}

	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Mob") {
			other.gameObject.GetComponent<UnitHealth> ().CurrentHealth -= damage;
			clonedParticule = Instantiate (damageParticule, transform.position, transform.rotation);
			timeToDestroy = 1f;
		}

	}

}
