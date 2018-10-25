using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainCollision : MonoBehaviour {

	public Animator anim;
	public bool onFountain = false;

	float timerStartTime;
	public float delayTime;
	bool fountainOn;

    public AudioSource fountainSound;

	// Use this for initialization
	void Start () {
		//StartCoroutine(WaterStuff());
	}

	// Update is called once per frame
	void Update () {
		if (fountainOn == false && onFountain == false && (Time.time >= (timerStartTime + delayTime))){
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
			fountainOn = true;
            fountainSound.Play();
            anim.SetBool("WaterOff", false);
			anim.SetBool("WaterOn", true);
			timerStartTime = Time.time;
		}

		if (fountainOn == true && (Time.time >= (timerStartTime + delayTime))){
            fountainSound.Stop();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
			fountainOn = false;
			anim.SetBool("WaterOff", true);
			anim.SetBool("WaterOn", false);
			timerStartTime = Time.time;
		}
	}

	public void OnTriggerEnter2D (Collider2D col) {
		onFountain = true;
		//Debug.Log("You're on the fountain");
	}

	public void OnTriggerExit2D (Collider2D col) {
		onFountain = false;
		//Debug.Log("You're not on the fountain");
	}

}
