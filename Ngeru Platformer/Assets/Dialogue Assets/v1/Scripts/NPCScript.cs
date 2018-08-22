using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour {

    public bool useOverlay;
    public int dialogueOption;
    public string text;
    public GameObject dialogue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //|||||||||||||||||||||
    //||| For Export    |||
    //|||||||||||||||||||||


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().CompareTag("Player"))
        {
            dialogue.GetComponent<DialogueScript>().HoverPrompt(gameObject.GetComponent<Transform>().position, useOverlay, text, dialogueOption);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().CompareTag("Player"))
        {
            dialogue.GetComponent<DialogueScript>().closeInterfaces();
        }
    }
}
    //|||||||||||||||||||||
    //||| For Export    |||
    //|||||||||||||||||||||

