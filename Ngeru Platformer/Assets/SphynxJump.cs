using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphynxJump : MonoBehaviour {

    public GameObject sphynx;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<ControllerPlayerScript>().isGrounded == false)
        {
            sphynx.SetActive(false);
        } else
        {
            sphynx.SetActive(true);
        }
	}
}
