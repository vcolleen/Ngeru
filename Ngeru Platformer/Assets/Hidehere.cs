using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidehere : MonoBehaviour {

    bool on;
    float mark;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (on && Time.time >= mark)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            mark = Time.time + 0.2f;
            on = false;
        }
        if (!on && Time.time >= mark)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            mark = Time.time + 0.2f;
            on = true;
        }
        

	}
}
