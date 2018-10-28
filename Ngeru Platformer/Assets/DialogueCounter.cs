using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCounter : MonoBehaviour {

    public GameObject ngeru;
    bool inBox;

    [SerializeField]
    private int counter;
    int i;

    // Use this for initialization
    void Start () {
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (inBox)
        {
            ngeru.GetComponent<ControllerPlayerScript>().jump = false;
        }

        if (inBox && Input.GetKeyDown(KeyCode.E))
        {
            if (i < counter)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                i++;
            } else
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = true;
                i = 0;
            }
        }

        if (ngeru.GetComponent<ControllerPlayerScript>().enabled == false)
        {
            ngeru.GetComponent<Animator>().SetBool("isIdle", true);
            ngeru.GetComponent<Animator>().SetBool("isWalkingLeft", false);
            ngeru.GetComponent<Animator>().SetBool("isWalkingRight", false);
            ngeru.GetComponent<Animator>().SetBool("isRunning", false);
            ngeru.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        inBox = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inBox = false;
    }
}
