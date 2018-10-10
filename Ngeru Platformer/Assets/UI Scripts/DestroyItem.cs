using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyItem : MonoBehaviour {

    public GameObject item;
    public GameObject tick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        tick.SetActive(true);
    }
}
