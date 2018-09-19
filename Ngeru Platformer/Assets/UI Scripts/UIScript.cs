﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour {

    public GameObject objective;
    public GameObject inv;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.H))
        {
            if (objective.activeSelf == false)
            {
                objective.SetActive(true);
            }
            else
            {
                objective.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inv.activeSelf == false)
            {
                inv.SetActive(true);
            }
            else
            {
                inv.SetActive(false);
            }
        }
	}

    public void PressHelp()
    {
        if (objective.activeSelf == false)
        {
            objective.SetActive(true);
        }
        else
        {
            objective.SetActive(false);
        }
    }

   /* public void OpenInv()
    {
        if (inv.activeSelf == false)
        {
            inv.SetActive(true);
        }
        else
        {
            return;
        }
    }*/

    public void CloseInv()
    {
        if (inv.activeSelf == true)
        {
            inv.SetActive(false);
        }
        else
        {
            return;
        }
    }
}
