using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEntranceScript : MonoBehaviour
{

    public int rsTimer;
    public bool isSpawned;
    public float randomNumber = 10f;
    public float randomTime = 10f;
    public float minRange;
    public float maxRange;
    public Vector3 spawnPos;

    public GameObject background;
    public GameObject humanAI;
    public GameObject lineRenderer;
    public GameObject hideUI;
    public Image fadePanel;
    public GameObject Player;

    public float executeTime;
    public bool waiting;
    public Vector2 playerSpawnPos;

    void Start()
    {
        //randomTime = 10f;
        //Debug.Log("Random Time " + randomTime);
        playerSpawnPos = Player.GetComponent<Transform>().position;
        //hideUI.GetComponent<Text>().enabled = false;
    }

    void Update()
    {
        Debug.Log("Random Time " + randomTime);
        SpawnTimer();
        AITimer();

        if (waiting  == true)
        {
            if (Time.time < executeTime)
            {
                fadePanel.GetComponent<Animator>().SetBool("FadeIn", false);
                fadePanel.GetComponent<Animator>().SetBool("FadeOut", true);
                //Disable Player Movement
            }

            else if (Time.time > executeTime)
            {
                Debug.Log("toosoon");
                fadePanel.GetComponent<Animator>().SetBool("FadeIn", true);
                fadePanel.GetComponent<Animator>().SetBool("FadeOut", false);
                waiting = false;
                
                Player.GetComponent<Transform>().position = playerSpawnPos;
                //Reset UI
                //Reset Objects
                //ResetAI
                //Enable Player Movement
            }
        }

        if (isSpawned == false)
        {

            //lineRenderer.GetComponent<LineRenderer>().enabled = false;
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

    public void Caught()
    {
        //Destroy(gameObject);
        executeTime = (Time.time + 5f);
        waiting = true;
        Debug.Log("AAAAAA");
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
            spawnPos = new Vector3((tileWidth / 2f) - 1.2f, transform.position.y, transform.position.z);
            Instantiate(humanAI, spawnPos, Quaternion.identity);
            isSpawned = true;
            randomNumber = Random.Range(minRange, maxRange);
            Debug.Log("Spawn");

        }
    }
}
