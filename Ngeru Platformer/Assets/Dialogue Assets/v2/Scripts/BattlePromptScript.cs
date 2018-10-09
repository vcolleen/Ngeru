using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePromptScript : MonoBehaviour {

    //variables


    //References


    void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponentInParent<BattleTargetScript>().Interact();
            Destroy(gameObject);
        }
	}

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
