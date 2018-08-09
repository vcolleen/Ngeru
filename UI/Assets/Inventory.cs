using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject inv;
    public GameObject close;
    public GameObject banner;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PressButton()
    {
        if (inv.activeSelf == false)
        {
            inv.SetActive(true);
            close.SetActive(true);
        }
        else
        {
            return;
        }
    }

    public void CloseInv()
    {
        if (inv.activeSelf == true)
        {
            inv.SetActive(false);
            close.SetActive(false);
        } else
        {
            return;
        }

    }

    public void OpenBanner()
    {
        if (banner.activeSelf == false)
        {
            banner.SetActive(true);
        }
        else
        {
            banner.SetActive(false);
        }

    }
}
