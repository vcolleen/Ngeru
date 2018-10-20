using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectScript : MonoBehaviour {

	public float xForceR1 = 50f;
	public float xForceR2 = 200f;
	private float xForce;
	public float yForce = 0f;

	// Use this for initialization
	void Start () {
		
	}

	void Awake () {

		xForce = Random.Range (xForceR1, xForceR2);

		if (gameObject.transform.position.x <= -0.1) {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (xForce, yForce));
		} else {
			gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (xForce * -1, yForce));
		}
	}
	// Update is called once per frame
	void Update () {

		if (transform.position.y <= -2) {
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.tag == "Player") {
			Destroy (other.gameObject);
		}

	}
}
