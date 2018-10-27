using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouchW : MonoBehaviour {

    public GameObject wBut;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D (Collider2D col)
    {

        wBut.SetActive(true);
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        wBut.SetActive(false);
    }
}
