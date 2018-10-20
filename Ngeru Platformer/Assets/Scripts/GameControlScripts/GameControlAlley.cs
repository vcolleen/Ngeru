using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlAlley : MonoBehaviour {

	public GameObject fallL1;
	public GameObject fallL2;
	public GameObject fallObject;

	private float spawnRangeX;
	private float spawnPosX;

	private float spawnRangeY;
	private float spawnPosY;

	private Vector2 spawnPos;

	private float spawnTime;


	// Use this for initialization
	void Start () {
		spawnRangeX = fallL2.transform.position.x - fallL1.transform.position.x;
		spawnRangeY = fallL2.transform.position.y - fallL1.transform.position.y;


	}
	
	// Update is called once per frame
	void Update () {

		if (spawnTime <= Time.time) {
			SpawnFalling ();
		}

	}

	void SpawnFalling () {


		spawnPosX = Random.Range(fallL1.transform.position.x, (fallL1.transform.position.x + spawnRangeX));
		spawnPosY = Random.Range(fallL1.transform.position.y, (fallL1.transform.position.y + spawnRangeY));

		spawnPos = new Vector2 (spawnPosX, spawnPosY);
		Instantiate (fallObject, spawnPos, Quaternion.identity);

		spawnTime = Time.time + 2;

	}
}
