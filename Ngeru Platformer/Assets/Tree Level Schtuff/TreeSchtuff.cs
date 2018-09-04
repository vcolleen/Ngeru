using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeSchtuff : MonoBehaviour {

    public GameObject pressE;
    public GameObject ngeru;
    public GameObject winner;
    private int i = 0;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (pressE.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            ngeru.transform.position = new Vector3(-1.934f, -0.99f, 0);
            i++;
        }

        if (i == 3)
        {
            winner.SetActive(true);
            ngeru.transform.position = new Vector3(-1.934f, -0.99f, 0);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ngeru.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            pressE.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        pressE.SetActive(false);
    }
}
