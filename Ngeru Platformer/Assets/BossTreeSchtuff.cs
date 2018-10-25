using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTreeSchtuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.GetComponent<Animator>().SetBool("Happy", true);
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        gameObject.GetComponent<Animator>().SetBool("Happy", false);
    }
}
