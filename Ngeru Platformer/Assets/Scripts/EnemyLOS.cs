﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLOS : MonoBehaviour
{

    public float distance;

    public LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;

    void Start()
    {

        Physics2D.queriesStartInColliders = false;
    }

    void Awake()
    {

        //lineOfSight = GameObject.Find("LineOfSight").GetComponent<LineRenderer>();

    }

    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(new Vector3(transform.position.x, (transform.position.y + 0.25f), transform.position.z), transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(new Vector3(transform.position.x, (transform.position.y + 0.25f), transform.position.z), hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = redColor;

            if (hitInfo.collider.CompareTag("Player"))
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, new Vector3(transform.position.x, (transform.position.y + 0.25f), transform.position.z) + transform.right * distance);
            lineOfSight.colorGradient = greenColor;
        }

        lineOfSight.SetPosition(0, new Vector3(transform.position.x, (transform.position.y + 0.25f), transform.position.z));

    }
}
