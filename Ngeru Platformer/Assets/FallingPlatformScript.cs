﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformScript : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 initialPosition;
    bool platformMovingBack;

    public float fallingPlatform = 3f;
    float startFalling = 5f;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (platformMovingBack)
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, 20f * Time.deltaTime);

        if (transform.position.y == initialPosition.y)
            platformMovingBack = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Ngeru") && !platformMovingBack)
        {
            startFalling = (Time.time + fallingPlatform);
            Invoke("DropPlatform", 1f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
        Invoke("GetPlatformBack", 1f);
    }

    void GetPlatformBack()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        platformMovingBack = true;
    }

}
