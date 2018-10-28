using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
            } else
            {
                Time.timeScale = 0f;
            }
        }
	}
}
