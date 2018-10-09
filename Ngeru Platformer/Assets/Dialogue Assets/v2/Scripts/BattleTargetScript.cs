using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BattleTargetScript : MonoBehaviour
{

    public bool playerInCollider;

    public GameObject prompt;
    public Transform dialogueAnchor;
    public GameObject battleChoice;
    public string objectName;
    public GameObject objectiveMarker;
    public bool leadsToBattle;
    public bool isBroken;
    bool waitForBroken;
    // add reference to battle scene here

    void Start()
    {
        waitForBroken = true;
    }

    void Update()
    {
        if (isBroken && waitForBroken)
        {
            //set animation to broken
            waitForBroken = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().CompareTag("Player") && isBroken == false)
        {
            playerInCollider = true;
            Prompt();
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        playerInCollider = false;
    }

    public void Prompt()
    {
        Instantiate(prompt, dialogueAnchor, false) ;
    }

    public void Interact ()
    {
        Instantiate(battleChoice, gameObject.GetComponent<Transform>());
    }

    public void Yes()
    {
        GetComponentInChildren<BattleChoiceScript>().Die();
        if (leadsToBattle)
        {
            //link to battle scene here
        }
        else
        {
            isBroken = true;
        }
        if (playerInCollider)
        {
            //Prompt();
        }
        objectiveMarker.SetActive(true);

    }

    public void No()
    {
        GetComponentInChildren<BattleChoiceScript>().Die();
        if (playerInCollider)
        {
            Prompt();
        }
    }
}
