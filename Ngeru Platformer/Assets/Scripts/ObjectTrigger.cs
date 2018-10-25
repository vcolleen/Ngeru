using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour {

    Animator anim;
    public bool inside;
    //public GameObject item;
    public GameObject tick;
    public Rigidbody2D m_Rigidbody;

    public GameObject cat;
    Animator ngeru;

    public AudioSource kapowSound;

    //public GameObject a, b, c, d, e, f, g;
    public bool gotItems;
    public bool combat;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        ngeru = cat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (inside == true)
        {
            anim.SetBool("inside", true);
            if (Input.GetAxis("Trigger") == 1)
            {
                kapowSound.Play();
                if (combat)
                {
                    //Start Combat Here
                }

                ngeru.SetLayerWeight(4, 1);
                ngeru.SetLayerWeight(2, 0);
                ngeru.SetTrigger("Swipe");
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

                gameObject.GetComponent<ObjectTrigger>().enabled = false;

            }
        }

        if (inside == false)
        {
            anim.SetBool("inside", false);
        }

        //if (e.activeInHierarchy) {
        //    Debug.Log("Gotta catch em all");
        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().CompareTag("Player"))
        {
            inside = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().CompareTag("Player"))
        {
            inside = false;
        }
    }


}
