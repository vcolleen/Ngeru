using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour {

    Animator anim;
    public bool inside;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (inside == true)
        {
            anim.SetBool("inside", true);
            if(Input.GetKeyDown("e"))
            {
                anim.SetTrigger("play");
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inside = true;
    }


}
