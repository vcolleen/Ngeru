using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoop : MonoBehaviour {

    public MovieTexture movTexture;
    public GameObject movTexture2;

    // Use this for initialization
    void Start () {
        movTexture.loop = true;
        movTexture.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        movTexture.Stop();
        movTexture2.SetActive(true);
    }
}
