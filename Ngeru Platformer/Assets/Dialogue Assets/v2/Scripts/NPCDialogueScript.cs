using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NPCDialogueScript : MonoBehaviour {
    //Variables
    public bool useOverlay;
    public bool isCombatNPC;
    public bool playerInCollider;

    //Referenes
    public GameObject dialogueManager;
    public GameObject promtPrefab;
    public GameObject overlay;
    public GameObject bubble;
    public Transform dialogueAnchor;
    public Button button;

    public Sprite portrait;

    public TextAsset textFile1;
    public TextAsset textFile2;
    public TextAsset textFile3;
    public TextAsset textFile4;
    public TextAsset textFile5;

    void Start () {

    }
	
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().CompareTag("Player"))
        {
            Prompt();
            playerInCollider = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        playerInCollider = false;
    }

    public void Interact()
    {
        if (useOverlay)
        {
            Instantiate(overlay, gameObject.GetComponent<Transform>().position, new Quaternion(0,0,0,0) ,gameObject.GetComponent<Transform>());
            GetComponentInChildren<DialogueOverlayScript>().storedText = textFile1.text;
            GetComponentInChildren<DialogueOverlayScript>().storedPortrait = portrait;
            if (isCombatNPC)
            {
                ButtonStateSwap();
            }
        }

        else
        {
            Instantiate(bubble, dialogueAnchor, false);
            GetComponentInChildren<PopUpBubbleScript>().storedText = textFile1.text;
        }
    }

    public void Prompt ()
    {
        Instantiate(promtPrefab, dialogueAnchor, false);

    }

    public void ButtonStateSwap()
    {
        Debug.Log("turn off button");
        button.interactable = !button.interactable;
    }

}
