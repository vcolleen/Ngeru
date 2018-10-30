using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEntranceScript : MonoBehaviour
{

    public int rsTimer;
    public bool isSpawned;
    public float randomNumber = 20f;
    public float randomTime = 20f;
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
    public GameObject aiRef;
    public GameObject caughtCanvas;

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
                Player.GetComponent<ControllerPlayerScript>().enabled = false;
                caughtCanvas.SetActive(true);
                Debug.Log("aeiou!!!");
                //Disable Player Movement
            }

            else if (Time.time > executeTime)
            {
                Debug.Log("toosoon");
                fadePanel.GetComponent<Animator>().SetBool("FadeIn", true);
                fadePanel.GetComponent<Animator>().SetBool("FadeOut", false);

                //isSpawned = false;
                Destroy(aiRef);
                randomTime = (rsTimer + randomNumber);
                isSpawned = false;
                Player.GetComponent<Transform>().position = playerSpawnPos;
                Player.GetComponent<ControllerPlayerScript>().enabled = true;
                caughtCanvas.SetActive(false);
                waiting = false;
            }
        }

        if (isSpawned == false)
        {
            hideUI.SetActive(false);
            //lineRenderer.GetComponent<LineRenderer>().enabled = false;
            if ((randomTime - Time.time) <= 8f)
            {
                //hideUI.GetComponent<Text>().enabled = true;
                hideUI.SetActive(true);
                hideUI.GetComponent<SpriteRenderer>().enabled = true;
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
        hideUI.SetActive(false);
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

        if (Time.time >= randomTime && waiting == false)
        {
            SpawnAI();

        }
    }

    void SpawnAI()
    {

        if (isSpawned == false && waiting == false)
        {
            float tileWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
            spawnPos = new Vector3((tileWidth / 2f), transform.position.y, transform.position.z);
            Instantiate(humanAI, spawnPos, Quaternion.identity);
            isSpawned = true;
            randomNumber = Random.Range(minRange, maxRange);
            Debug.Log("Spawn");
            aiRef = GameObject.Find("Human(Clone)");
        }
    }
}
