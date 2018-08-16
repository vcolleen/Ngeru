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

    public void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
        item.SetActive(false);
        tick.SetActive(true);
    }
}
