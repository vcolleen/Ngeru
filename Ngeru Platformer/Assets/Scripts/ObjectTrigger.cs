using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour {

    Animator anim;
    public bool inside;
    public GameObject item;
    public GameObject tick;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(Input.GetAxis("Trigger"));

        if (inside == true)
        {
            anim.SetBool("inside", true);
            if (Input.GetAxis("Trigger") == 1)
            {
                anim.SetTrigger("play");
                tick.SetActive(true);
            }
        }

        if (inside == false)
        {
            anim.SetBool("inside", false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inside = false;
    }


}
