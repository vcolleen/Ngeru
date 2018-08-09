using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeDestroy1 : MonoBehaviour {

    public GameObject thing;
    public GameObject tick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Destroy(gameObject);
        thing.SetActive(false);
        tick.SetActive(true);
    }
}
