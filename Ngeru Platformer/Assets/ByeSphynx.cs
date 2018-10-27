using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByeSphynx : MonoBehaviour {

    public GameObject ngeru;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<SpriteRenderer>().color.a == 0)
        {
            ngeru.GetComponent<ControllerPlayerScript>().enabled = true;
            gameObject.SetActive(false);
        }
	}
}
