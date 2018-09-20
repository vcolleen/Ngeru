using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
