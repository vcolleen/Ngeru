using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDelay : MonoBehaviour {

    public GameObject aiHuman;
    public GameObject hideHere;

    // Use this for initialization
    void Start () {
        StartCoroutine(Delay());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(20);
        aiHuman.SetActive(true);
        hideHere.SetActive(true);
    }
}
