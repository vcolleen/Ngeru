using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlAlley : MonoBehaviour {

	public GameObject fallL1;
	public GameObject fallL2;
	public GameObject fallObject;

	private float spawnRange;
	private float spawnPosX;
	private Vector2 spawnPos;

	private float spawnTime;


	// Use this for initialization
	void Start () {
		spawnRange = fallL2.transform.position.x - fallL1.transform.position.x;


	}
	
	// Update is called once per frame
	void Update () {

		if (spawnTime <= Time.time) {
			SpawnFalling ();
		}

	}

	void SpawnFalling () {


		spawnPosX = Random.Range(fallL1.transform.position.x, (fallL1.transform.position.x + spawnRange));
		spawnPos = new Vector2 (spawnPosX, fallL1.transform.position.y);
		Instantiate (fallObject, spawnPos, Quaternion.identity);
		spawnTime = Time.time + 2;

	}
}
