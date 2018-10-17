using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour {

    Animator anim;
    public bool inside;
    public GameObject item;
    public GameObject tick;
    public Rigidbody2D m_Rigidbody; 


    public GameObject a, b, c, d, e, f, g;
    public bool gotItems; 

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (inside == true)
        {
            anim.SetBool("inside", true);
            if (Input.GetAxis("Trigger") == 1)
            {
                anim.SetTrigger("play");
                tick.SetActive(true);
                m_Rigidbody = GetComponent<Rigidbody2D>();
                try
                {
                    m_Rigidbody.bodyType = RigidbodyType2D.Dynamic;
                }
                catch (MissingComponentException)
                {
                    Debug.Log("Object has no rigibody2d");
                }

            }
        }

        if (inside == false)
        {
            anim.SetBool("inside", false);
        }

        if (e.activeInHierarchy) {
            Debug.Log("Gotta catch em all");
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
