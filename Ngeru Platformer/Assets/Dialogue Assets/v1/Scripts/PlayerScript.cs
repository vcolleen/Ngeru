using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    //Variables
    private float h;
    public float speed;

    public bool canMove = true;

    public GameObject dialogue;
    GameObject currentTrigger;

    //collision.GetComponent<Transform>().position
    //Functions
    void Start () {
		
	}
	
	void Update () {
		
	}
    //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv----moving----vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
    public void FixedUpdate()
    {
       h = Input.GetAxis("Horizontal");
        if (canMove)
        {
            if (h > 0)
            {
                gameObject.transform.Translate(new Vector2(speed, 0));
            }

            else if (h < 0)
            {
                gameObject.transform.Translate(new Vector2(-speed, 0));
            }
        }

    }
    //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
   // public void OnTriggerEnter2D(Collider2D collision)
   // {
    //if (collision.GetComponent<Transform>().CompareTag("NPC"))
       // {
         //   dialogue.GetComponent<DialogueScript>().Enter(collision.GetComponent<Transform>().position);
       // }
   // }

   // public void OnTriggerExit2D(Collider2D collision)
  //  {
       // if (collision.GetComponent<Transform>().CompareTag("NPC"))
       // {

       //     dialogue.GetComponent<DialogueScript>().Exit();
       // }
    //}
}
