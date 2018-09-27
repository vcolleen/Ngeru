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
    // add reference to battle scene here

    void Start()
    {
        Debug.Log("start");
    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        playerInCollider = true;
        Prompt();
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
        //Link to battle scene here
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
