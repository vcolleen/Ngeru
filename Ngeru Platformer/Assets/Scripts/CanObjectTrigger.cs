﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanObjectTrigger : MonoBehaviour {

    Animator anim;
    public bool inside;
    //public GameObject item;
    public GameObject tick;

    public Rigidbody2D rigid;

    public GameObject cat;
    Animator ngeru;

    public AudioSource kapowSound;

    //public GameObject a, b, c, d, e, f, g;
    public bool gotItems;
    public bool combat;

    public GameObject eBut;
    bool eButActive = true;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        ngeru = cat.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
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

                ngeru.SetTrigger("Swipe");
                anim.SetTrigger("play");
                ngeru.SetLayerWeight(4, 1);
                ngeru.SetLayerWeight(2, 0);
                rigid.bodyType = RigidbodyType2D.Dynamic;
                tick.SetActive(true);
                eButActive = false;
                gameObject.GetComponent<CanObjectTrigger>().enabled = false;

            }
        }

        if (inside == false)
        {
            anim.SetBool("inside", false);
        }

        //if (e.activeInHierarchy) {
        //    Debug.Log("Gotta catch em all");
        //}

        if (eButActive == false)
        {
            eBut.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().CompareTag("Player"))
        {
            inside = true;
            if (eButActive)
            {
                eBut.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().CompareTag("Player"))
        {
            inside = false;
            if (eButActive)
            {
                eBut.SetActive(false);
            }
        }
    }


}