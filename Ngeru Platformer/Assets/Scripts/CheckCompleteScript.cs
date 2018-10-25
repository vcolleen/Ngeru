using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCompleteScript : MonoBehaviour {

    public GameObject paw0;
    public bool zero;
    public GameObject paw1;
    public bool one;
    public GameObject paw2;
    public bool two;
    public GameObject paw3;
    public bool three;
    public GameObject paw4;
    public bool four;
    public GameObject paw5;
    public bool five;
    public GameObject paw6;
    public bool six;

    public GameObject plant;
    public GameObject plantCol;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (paw0.activeInHierarchy)
        {
            zero = true;
        }
        if (paw1.activeInHierarchy)
        {
            one = true;
        }
        if (paw2.activeInHierarchy)
        {
            two = true;
        }
        if (paw3.activeInHierarchy)
        {
            three = true;
        }
        if (paw4.activeInHierarchy)
        {
            four = true;
        }
        if (paw5.activeInHierarchy)
        {
            five = true;
        }
        if (paw6.activeInHierarchy)
        {
            six = true;
        }


        if (zero && one && two && three && four && five && six)
        {
            //Enter Cutscene
        } else if (zero && one && two && three && four && five)
        {
            plant.SetActive(true);
            plantCol.SetActive(true);
        }
    }
}
