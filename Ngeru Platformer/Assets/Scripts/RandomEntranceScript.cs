using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEntranceScript : MonoBehaviour {

	public int rsTimer;
	public bool isSpawned;
    public float randomNumber;
    public float randomTime;
    public float minRange;
    public float maxRange;

	public GameObject humanAI;
    public GameObject lineRenderer;

    
	void Update ()
    {

		AITimer ();
		SpawnTimer ();

        if (isSpawned == false)
        {

            lineRenderer.GetComponent<LineRenderer>().enabled = false;

        } else
        {
            lineRenderer.GetComponent<LineRenderer>().enabled = true;
        }

	}

	void AITimer ()
    {

		if (Time.time > rsTimer)
        {

			rsTimer += 1;
			Debug.Log(rsTimer);

		}
	}

	void SpawnTimer ()
    {
        if (Time.time >= randomTime)
        {

            SpawnAI();

        }
	}

	void SpawnAI ()
    {

        if (isSpawned == false)
        {
            
            Instantiate(humanAI, transform.position, Quaternion.identity);
            isSpawned = true;
            randomNumber = Random.Range(minRange, maxRange);

        }        	
	}
}
