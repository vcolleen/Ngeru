using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphynxCollider : MonoBehaviour {

    public GameObject ngeru;
    public bool ngeruAnim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ngeruAnim)
        {

            ngeru.GetComponent<Animator>().SetBool("isIdle", true);

            if (ngeru.GetComponent<Animator>().GetBool("isIdle") == true && ngeru.GetComponent<Animator>().GetBool("isWalkingLeft") == false && ngeru.GetComponent<Animator>().GetBool("isWalkingRight") == false)
            {

                if (Input.GetAxis("Trigger") == 1)
                {
                    ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                }

            }

        } else
        {
            ngeru.GetComponent<ControllerPlayerScript>().enabled = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ngeruAnim = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        ngeruAnim = false;
    }
}
