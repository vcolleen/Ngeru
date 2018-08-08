using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

	public float speed;
	public float distance;

    public float lifeSpan;
    private float timeAlive;
    private float spawnTime;
 
	private bool movingRight = true;

	public Transform groundDetection;

    RandomEntranceScript rEntranceScript;

    void Awake()
    {

        rEntranceScript = GameObject.Find("AIController").GetComponent<RandomEntranceScript>();
        spawnTime = Time.time;
        timeAlive = 0f;

    }

	void Update()
    {

        LifeCycle();

        transform.Translate(Vector2.right * speed * Time.deltaTime);

		RaycastHit2D groundInfo = Physics2D.Raycast (groundDetection.position, Vector3.down, distance);
		if (groundInfo.collider == false)
        {
			if(movingRight == true)
            {

				transform.eulerAngles = new Vector3(0, -180, 0);
				movingRight = false;

			}
            else
            {
				transform.eulerAngles = new Vector3(0, 0, 0);
				movingRight = true;
			}

		}

	}

    void LifeCycle ()
    {

        timeAlive = (Time.time - spawnTime);

        if (timeAlive >= lifeSpan)
        {

            Destroy(gameObject);
            rEntranceScript.isSpawned = false;
            rEntranceScript.randomTime = (rEntranceScript.rsTimer + rEntranceScript.randomNumber);

        }

    }

}
