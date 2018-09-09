using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnBased : MonoBehaviour {

	PlayerHealth player;
	public GameObject person;

	// Use this for initialization
	void Start () {
		player = person.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit() {
	player.Strike();
    }
}
