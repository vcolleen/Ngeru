using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomEntranceScript : MonoBehaviour
{

    public int rsTimer;
    public bool isSpawned;
    public float randomNumber = 20f;
    public float randomTime = 40f;
    public float minRange;
    public float maxRange;
    public Vector3 spawnPos;

    public GameObject background;
    public GameObject humanAI;
    public GameObject lineRenderer;
    public GameObject hideUI; // HireHere 
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

    // Only resets the randomNumber to 20f at the moment
    // TODO: this should be called when initialized, but also after you die
    private void Init()
    {

        //rsTimer = 0;
       // randomNumber = 20f;
        Debug.Log("randomTime 0 before: " + randomTime);
        //randomTime = 40f;
        Debug.Log("randomTime 0 after: " + randomTime);
    }

    void Update()
    {
        Debug.Log("Random Time 3: " + randomTime);
        SpawnTimer();
        AITimer();

        if (waiting  == true)
        {

            // after human ?
            if (Time.time < executeTime)
            {

                
                fadePanel.GetComponent<Animator>().SetBool("FadeIn", false);
                fadePanel.GetComponent<Animator>().SetBool("FadeOut", true);
                Player.GetComponent<ControllerPlayerScript>().enabled = false;
                caughtCanvas.SetActive(true);
                //Debug.Log("if 1 !!!" + " time: " + Time.time + " executeTime: " + executeTime);
                
                //Disable Player Movement
            }

            // Caught, Destroy Human
            else if (Time.time > executeTime)
            {
                
                //Debug.Log("if 2 !!!" + " time: " + Time.time + " executeTime: " + executeTime);
                fadePanel.GetComponent<Animator>().SetBool("FadeIn", true);
                fadePanel.GetComponent<Animator>().SetBool("FadeOut", false);

                //isSpawned = false;
                Destroy(aiRef);
                //print("randomTime 1 before: " + randomTime);
                //randomTime = (rsTimer + randomNumber);
                randomTime += 40f;

                //print("randomTime 1 after: " + randomTime);
                isSpawned = false;
                Player.GetComponent<Transform>().position = playerSpawnPos;
                Player.GetComponent<ControllerPlayerScript>().enabled = true;
                caughtCanvas.SetActive(false);
                waiting = false;
            }
        }

        // Exclamation Mark UI
        if (isSpawned == false)
        {
            hideUI.SetActive(false);
            //lineRenderer.GetComponent<LineRenderer>().enabled = false;
            if ((randomTime - Time.time) <= 5f)
            {

                // show HireHere (exclamation mark)
                hideUI.SetActive(true);
                hideUI.GetComponent<SpriteRenderer>().enabled = true;
            }

        }
       

    }

    public void Caught()
    {
        //Destroy(gameObject);
        executeTime = (Time.time + 5f);
        waiting = true;
        hideUI.SetActive(false);
        Debug.Log("Caught()");

        //TODO: make sure this is called after death, if needed
        Init();

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
            randomTime += 50f;
            Debug.Log("Spawn");
            aiRef = GameObject.Find("Human(Clone)");
        }
    }
}
