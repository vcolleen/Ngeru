﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    //calling the animator
    public Animator anim;



    public float speed;
    public float distance;

    private float timeAlive;
    private float spawnTime;

    private bool moving = true;

    public Transform groundDetection;

    RandomEntranceScript rEntranceScript;

    void Awake()
    {

    
        spawnTime = Time.time;
        timeAlive = 0f;

    }

    void Update()
    {

        LifeCycle();

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector3.down, distance);
        if (groundInfo.collider == false)
        //Debug.Log ("NotHittingAnything");
        {
            if (moving == true)
            {
                //anim.SetBool("WalkRight", true);
                transform.eulerAngles = new Vector3(0, -180, 0);
                moving = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moving = true;
            }

        }

    }

    public void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.GetComponent<Transform>().CompareTag("Player"))
        {
            //Destroy(collider.gameObject);
            rEntranceScript.Caught();
            
        }
    }

    void LifeCycle()
    {

        timeAlive = (Time.time - spawnTime);

        //if (transform.position.x >= rEntranceScript.spawnPos.x && timeAlive >= 2)
    
            {
            Die();

        }

    }

    public void Die()
    {
        
        rEntranceScript.isSpawned = false;
        rEntranceScript.randomTime = (rEntranceScript.rsTimer + rEntranceScript.randomNumber);
        Destroy(gameObject);
        Debug.Log("Die");
    }

}
