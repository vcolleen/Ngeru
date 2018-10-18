using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEntranceScript : MonoBehaviour
{

    public int rsTimer;
    public bool isSpawned;
    public float randomNumber;
    public float randomTime;
    public float minRange;
    public float maxRange;
    public Vector3 spawnPos;

    public GameObject background;
    public GameObject humanAI;
    public GameObject lineRenderer;
    public GameObject hideUI;

    void start()
    {
        hideUI.GetComponent<Text>().enabled = false;
    }

    void Update()
    {

        AITimer();
        SpawnTimer();

        if (isSpawned == false)
        {

            lineRenderer.GetComponent<LineRenderer>().enabled = false;
            if ((randomTime - Time.time) <= 5f)
            {
                //hideUI.GetComponent<Text>().enabled = true;
            }

        }
        else
        {
            //lineRenderer.GetComponent<LineRenderer>().enabled = true;
            //hideUI.GetComponent<Text>().enabled = false;

        }

    }

    void AITimer()
    {

        if (Time.time > rsTimer)
        {

            rsTimer += 1;

        }
    }

    void SpawnTimer()
    {

        if (Time.time >= randomTime)
        {

            SpawnAI();

        }
    }

    void SpawnAI()
    {

        if (isSpawned == false)
        {
            float tileWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
            spawnPos = new Vector3(tileWidth / 2 + 0, transform.position.y, transform.position.z);
            Instantiate(humanAI, spawnPos, Quaternion.identity);
            isSpawned = true;
            randomNumber = Random.Range(minRange, maxRange);

        }
    }
}
