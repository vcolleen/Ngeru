using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject whitePicture;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WhitePicture ()
    {
        if (whitePicture.activeSelf)
        {
            whitePicture.SetActive(false);
        } else
        {
            whitePicture.SetActive(true);
        }
    }
}
