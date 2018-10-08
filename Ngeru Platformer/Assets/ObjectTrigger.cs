using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown("e"))
        {
            anim.SetTrigger("Touched");
        }
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit Item");
    }
}
