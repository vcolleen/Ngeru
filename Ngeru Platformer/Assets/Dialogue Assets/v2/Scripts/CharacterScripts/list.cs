using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class list : MonoBehaviour {

    public List<float> listTest = new List<float>();

	// Use this for initialization
	void Start () {
        listTest.Add(1f);
        listTest.Add(13f);
        listTest.Add(400f);
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(listTest[0]);
        Debug.Log(listTest[1]);
        Debug.Log(listTest[2]);
    }
}
