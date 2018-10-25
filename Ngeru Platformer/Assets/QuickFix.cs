using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickFix : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (p1.activeSelf && p2.activeSelf && p3.activeSelf && p4.activeSelf && p5.activeSelf && p6.activeSelf)
        {
            SceneManager.LoadScene("Cutscene03");
        }
	}
}
