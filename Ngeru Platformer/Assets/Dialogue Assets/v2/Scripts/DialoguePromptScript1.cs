using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePromptScript1 : MonoBehaviour {

    //variables


    //References


    void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponentInParent<NPCDialogueScript1>().Interact();
            Destroy(gameObject);
        }
	}

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().CompareTag("Player"))
        {
            Destroy(gameObject);
            //Debug.Log("PLS");
        }
    }
}
