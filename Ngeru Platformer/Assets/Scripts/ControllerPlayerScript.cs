﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerScript : MonoBehaviour
{

    //Player Variables
    private Rigidbody2D myRigidBody;
    public float movementSpeed;
    public Transform[] groundPoints;
    public float groundRadius;

    //Jumping Variables
    public bool isGrounded;
    public bool jump;
    public float jumpForce;
    public LayerMask whatIsGround;

    public float timeBetweenJumps;
    float nextJump;

    //Movement Variables
    private bool isIdle;
    public bool isWalkingRight;
    public bool isWalkingLeft;
    private bool isTurningRight;
    private bool isTurningLeft;
    private bool isRunning;
    private bool CanTurnLeft;
    private bool CanTurnRight;
    public bool landing;
    

    //laying down timing
    bool isWaitingForIdle;
    bool isWaitingForSuperIdle;
    public float timeBeforeLayDown = 3;
    public float timeBeforeSitDown = 3;
    float startIdle = 5f;
    float startSitting = 10f;
    bool isSitting = false;

    //calling the animator
    Animator anim;

    //AI Variables
    public bool isHiding;
    private bool isOverlaping = false;

    public AudioSource jumpSound;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        Time.timeScale = 1f;

        anim = GetComponent<Animator>();
        anim.SetBool("isWalkingRight", true);

        isWaitingForSuperIdle = true;
        isWaitingForIdle = true;
        isIdle = true;
        CanTurnRight = true;
    }

    private void Update()
    {
        //Jump-Movement
        HandleInput();


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
        if (Input.GetAxis("Run") > 0)
        {
            isRunning = true;
        }

        else
        {
            isRunning = false;
        }

        if (isRunning == true)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", false);
            movementSpeed = 2f;
            jumpForce = 230;
        }

        if (isRunning == false)
        {
            anim.SetBool("isRunning", false);
            movementSpeed = 0.8f;
            jumpForce = 190;
        }

        //WalkingRight
        if (Input.GetAxis("Horizontal") > 0)
        {
            isWalkingRight = true;
            isWalkingLeft = false;
            anim.SetTrigger("Turn");
        }

        else
        {
            isWalkingRight = false;
        }

        if (isWalkingRight == true)
        {
            anim.SetBool("isWalkingRight", true);
            anim.SetBool("CanTurnRight", true);
            anim.SetBool("CanTurnLeft", false);
        }

        if (isWalkingRight == false)
        {
            anim.SetBool("isWalkingRight", false);

        }

        //WalkingLeft
        if (Input.GetAxis("Horizontal") < 0)
        {
            isWalkingLeft = true;
            isWalkingRight = false;
            anim.SetTrigger("Turn");
        }
        else
        {
            isWalkingLeft = false;
        }

        if (isWalkingLeft == true)
        {
            anim.SetBool("isWalkingLeft", true);
            anim.SetBool("CanTurnLeft", true);
            anim.SetBool("CanTurnRight", false);
        }

        if (isWalkingLeft == false)
        {
            anim.SetBool("isWalkingLeft", false);

        }


        //Laying down
        if (isWalkingLeft == false)
        {
            if (isWalkingRight == false)
            {
                isIdle = true;

            }
        }

        if (isWalkingLeft)
        {
            isIdle = false;
            isSitting = false;
            isWaitingForIdle = true;
            anim.SetBool("isLayingDown", false);
            anim.SetBool("isSuperIdle", false);
        }
        if (isWalkingRight)
        {
            isIdle = false;
            isSitting = false;
            isWaitingForIdle = true;
            anim.SetBool("isLayingDown", false);
            anim.SetBool("isSuperIdle", false);
        }

        //Idle
        if (isIdle && !isHiding)
        {
            if (isWaitingForIdle)
            {
                startIdle = (Time.time + timeBeforeSitDown);
                isWaitingForIdle = false;
            }
            if (isWaitingForSuperIdle)
            {
                startSitting = (Time.time + timeBeforeLayDown);
                isWaitingForSuperIdle = false;
            }
            if (Time.time > startIdle)
            {
                anim.SetLayerWeight(2, 1);
                anim.SetBool("isLayingDown", true);
                isSitting = true;
            }
            if (Time.time > startSitting)
            {
                anim.SetBool("isSuperIdle", true);
            }
        }
    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        HandleLayers();

        ResetValues();
    }


    //Left to right movement
    private void HandleMovement(float horizontal)
    {
        if (myRigidBody.velocity.y < 0)
        {
            landing = true;
            anim.SetBool("Landing", true);

        }

        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        if (isGrounded && jump && !isHiding)
        {
            jumpSound.Play();
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, jumpForce));
            anim.SetBool("isIdle", false);
            anim.SetBool("isLayingDown", false);
            anim.SetBool("isSuperIdle", false);
            anim.SetTrigger("Jump");
        }
    }



    //Jump
    private void HandleInput()
    {
        if (Input.GetAxis("Jump") >= 1 && Time.time > nextJump)
        {
            jump = true;
            isIdle = false;
            isSitting = false;
            isWaitingForIdle = true;
            nextJump = (Time.time + timeBetweenJumps);
        }
        Hiding();
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
                        anim.ResetTrigger("Jump");
                        anim.SetBool("Landing", false);
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

    //Animation Layers for Jump
    private void HandleLayers()
    {
        if (!isGrounded)
        {
            anim.SetLayerWeight(1, 1);
            anim.SetLayerWeight(0, 0);
            anim.SetLayerWeight(2, 0);
        }

        else
        {
            anim.SetLayerWeight(1, 0);
            anim.SetLayerWeight(0, 1);
        }
    }

    void Hiding()
    {
        if (Input.GetAxis("Hide") == 1)
        {
            if (isOverlaping == true)
            {
                gameObject.layer = 2;
                isHiding = true;
                isIdle = false;
                anim.SetBool("isIdle", false);
                anim.SetBool("isSuperIdle", false);
                anim.SetLayerWeight(0, 1);
                anim.SetLayerWeight(1, 0);
                anim.SetLayerWeight(2, 0);
                gameObject.transform.position = GameObject.Find("HidingCouch").transform.position;
                //Debug.Log("isHiding");
                anim.SetBool("isHiding", true);
                anim.SetBool("AlreadyHiding", true);
            }
        }
        if (Input.GetAxis("Hide") == 0)
        {
            gameObject.layer = 10;
            isHiding = false;
            //Debug.Log("isn'tHiding");
            anim.SetBool("isHiding", false);
            anim.SetBool("AlreadyHiding", false);
            isIdle = false;
            anim.SetBool("isIdle", false);
            anim.SetBool("isSuperIdle", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "HidingCouch")
        {
            isOverlaping = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "HidingCouch")
        {
            isOverlaping = false;
        }
    }

    
}
