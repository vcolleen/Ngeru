using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NPCDialogueScript1 : MonoBehaviour {
    //Variables
    public bool playerInCollider;

    //Referenes
    public GameObject promtPrefab;
    public GameObject overlay;
    public Transform dialogueAnchor;
    public Sprite portrait;


    void Start () {

    }
	
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().CompareTag("Player"))
        {
            
            playerInCollider = true;
            Prompt();
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        playerInCollider = false;
    }

    public void Interact()
    {
        Instantiate(overlay, gameObject.GetComponent<Transform>().position, new Quaternion(0, 0, 0, 0), gameObject.GetComponent<Transform>());
    }

    public void Prompt ()
    {
        if (playerInCollider)
        {
            Instantiate(promtPrefab, dialogueAnchor, false);
        }
        

    }


}
