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

        if (Input.GetAxis("Trigger") == 1 && ngeruAnim)
        {
            ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ngeruAnim = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        ngeruAnim = false;
    }
}
