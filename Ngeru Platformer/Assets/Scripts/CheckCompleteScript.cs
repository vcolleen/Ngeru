using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCompleteScript : MonoBehaviour {

    public GameObject paw0;
    //public bool zero;
    public GameObject paw1;
    //public bool one;
    public GameObject paw2;
    //public bool two;
    public GameObject paw3;
    //public bool three;
    public GameObject paw4;
    //public bool four;
    public GameObject paw5;
    //public bool five;
    //public GameObject paw6;
    //public bool six;

    public GameObject plant;
    public GameObject plantCol;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (paw0.activeSelf == true && paw1.activeSelf == true && paw2.activeSelf == true && paw3.activeSelf == true && paw4.activeSelf == true && paw5.activeSelf == true)
        {
            plant.SetActive(true);
            plantCol.SetActive(true);
        }
    }
}
