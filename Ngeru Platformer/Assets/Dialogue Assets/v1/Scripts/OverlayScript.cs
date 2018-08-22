using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayScript : MonoBehaviour {
    public Text textref;
    public string storedText;
	// Use this for initialization
	void Start () {
        textref.text = storedText;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Activate") > 0)
        {
            GetComponentInParent<DialogueScript>().ReceiveInteraction();
        }
        
    }
}
