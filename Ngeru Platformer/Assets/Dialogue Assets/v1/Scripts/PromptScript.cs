using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Activate") > 0)
        {
            //GetComponentInParent<DialogueScript>().Next();
            GetComponentInParent<DialogueScript>().ReceiveInteraction();
        }
    }


}
