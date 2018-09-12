﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerScript : MonoBehaviour {

    //Player Variables 
    private Rigidbody2D myRigidBody;
    public float movementSpeed;
    public Transform[] groundPoints;
    public float groundRadius;

    //Jumping Variables
    private bool isGrounded;
    private bool jump;
    public float jumpForce;
    public LayerMask whatIsGround;

    //Movement Variables 
    public bool isIdle;
    public bool isWalkingRight;
    public bool isWalkingLeft;
    public bool isTurningRight;
    public bool isTurningLeft;
    public bool isJumping;
    public bool isRunning;


    //calling the animator
    Animator anim;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        anim.SetTrigger("isLookingRight");

        isIdle = true;
        isWalkingRight = false;
        isWalkingLeft = false;
        isTurningRight = false;
        isTurningLeft = false;
        isJumping = false;
        isRunning = false;
    }



    void Update()
    {
        //Jump-Movement 
        HandleInput();

        Debug.Log(Input.GetAxis("Jump"));


        //Animations & Keyboard Triggers 
        //Idle
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("isIdle", true);
        }

        else
        {
            anim.SetBool("isIdle", false);
        }

        //Run
        if(Input.GetAxis("Run") > 0)
        {
            isRunning = true;
        }

        else
        {
            isRunning = false;
        }

        if(isRunning == true)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", false);
            movementSpeed = 2f;
            jumpForce = 250;
        }

        if(isRunning == false)
        {
            anim.SetBool("isRunning", false);
            movementSpeed = 0.8f;
            jumpForce = 200;
        }

        //WalkingRight
        if(Input.GetAxis("Horizontal") > 0)
        {
            isWalkingRight = true;
            anim.SetTrigger("isLookingRight");
        }

        else
        {
            isWalkingRight = false;
        }

        if(isWalkingRight == true)
        {
            anim.SetBool("isWalkingRight", true);
        }

        if (isWalkingRight == false)
        {
            anim.SetBool("isWalkingRight", false);
        }

        //WalkingLeft 
        if(Input.GetAxis("Horizontal") < 0)
        {
            isWalkingLeft = true;
            anim.SetTrigger("isLookingLeft");
        }
        else
        {
            isWalkingLeft = false;
        }

        if(isWalkingLeft == true)
        {
            anim.SetBool("isWalkingLeft", true);
        }

        if (isWalkingLeft == false)
        {
            anim.SetBool("isWalkingLeft", false);

        }


    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        ResetValues();
    }


    //Left to right movement
    private void HandleMovement(float horizontal)
    {

        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, jumpForce));
            anim.SetBool("isJumping", true);
        }

        if(isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
    }

    

    //Jump
    private void HandleInput()
    {
        if (Input.GetAxis("Jump") >= 1)
        {
            jump = true;
            anim.SetBool("isIdle", false);
        }
    }

    //Indication that Ngeru is grounded
    public bool IsGrounded()
    {
        if (myRigidBody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }

                }
                
            }
            
        }
        return false;
    }

    private void ResetValues()
    {
        jump = false;
    }

   
}
