using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainCollision : MonoBehaviour {

	public Animator anim;
	bool onFountain = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(WaterStuff());
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col) {
		onFountain = true;
		Debug.Log("Hiilsdfgjhsdk;g;ksdjghsidhglksdgjljasdhgkljadshlgkjasdg");
	}

	void OnCollisionExit2D (Collision2D col) {
		onFountain = false;
	}

	IEnumerator WaterStuff() {
		if (anim.GetBool("WaterOff") == true && onFountain == true) {
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			yield return new WaitForSeconds(5);
			StartCoroutine(WaterStuff());
		} else if (anim.GetBool("WaterOn") == true && onFountain == false) {
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			yield return new WaitForSeconds(5);
			anim.SetBool("WaterOn", false);
			anim.SetBool("WaterOff", true);
			StartCoroutine(WaterStuff());
		} else if (anim.GetBool("WaterOff") == true && onFountain == false) {
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
			yield return new WaitForSeconds(5);
			anim.SetBool("WaterOn", true);
			anim.SetBool("WaterOff", false);
			StartCoroutine(WaterStuff());
		} else {
			yield return new WaitForSeconds(1);
			StartCoroutine(WaterStuff());
		}
	}

}
