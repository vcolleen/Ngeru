using System.Collections;
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
    bool isIdle;
    bool isTurningRight;
    bool isTurningLeft;
    bool isLookingLeft;
    bool isLookingRight;


    //calling the animator
    Animator anim;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        isIdle = true;
        isTurningRight = false;
        isTurningLeft = false;
        isLookingLeft = false;
        isLookingRight = true;

    }



    void Update()
    {
        //Jump-Movement 
        HandleInput();

        Debug.Log(Input.GetAxis("Horizontal"));

        //Animations & Keyboard Triggers 

        //Idle
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("isIdle", true);
        }

        //MovingLeft
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetTrigger("MoveLeft");
            anim.SetBool("isLookingLeft", true);
        }
        else
        {
            anim.SetBool("isIdle", false);
        }

        //MovingRight 
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetTrigger("MoveRight");
            anim.SetBool("isLookingRight", true);
        }
        else
        {
            anim.SetBool("isIdle", true);
        }


        //TurningRight
        if (anim.GetBool("isLookingLeft") == true)
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                anim.SetBool("isTurningRight", true);
            }
            else
            {
                anim.SetBool("isTurningRight", false);
            }
        }

        //TurningLeft
        if (anim.GetBool("isLookingRight") == true)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                anim.SetBool("isTurningLeft", true);
            }
            else
            {
                anim.SetBool("isTurningLeft", false);
            }
        }

    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        ResetValues();

        Debug.Log(Input.GetAxis("Jump"));
    }


    //Left to right movement
    private void HandleMovement(float horizontal)
    {

        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, jumpForce));

        }
    }

    

    //Jump
    private void HandleInput()
    {
        if (Input.GetAxis("Jump") == 1)
        {
            jump = true;
        }
    }

    //Indication that Ngeru is grounded
    private bool IsGrounded()
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
