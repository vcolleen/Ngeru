using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionScript : MonoBehaviour {

    public Sprite one;
    public Sprite two;
    public Transform dialogueAnchor;

    public GameObject prompt;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Transform>().CompareTag("Player"))
        {
            Instantiate(prompt, dialogueAnchor, false);
        }
    }
}
