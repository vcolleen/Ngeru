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
    public bool movementKeyDown = false;
    public bool isJumping = false;
    public float startIdle;
    public float waitTime;
    public bool isIdle;
    bool isLayingDown;

    //calling the animator
    Animator anim;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }



    void Update()
    {
        //Jump-Movement 
        HandleInput();

        //Animations & Keyboard Triggers 
        if (Input.GetKey(KeyCode.D))
        {
            if (movementKeyDown == false)
            {
                anim.SetTrigger("MoveRight");
                movementKeyDown = true;
            }

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            if (isJumping == false)
            {
                anim.SetTrigger("Stop");
            }
            movementKeyDown = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (movementKeyDown == false)
            {
                anim.SetTrigger("MoveLeft");
                movementKeyDown = true;
            }

        }


        if (Input.GetKeyUp(KeyCode.A))
        {
            if (isJumping == false)
            {
                anim.SetTrigger("Stop");
            }
            movementKeyDown = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            isJumping = true;
        }

    }

    //What stops the animation playing once Ngeru lands
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isJumping)
        {
            isJumping = false;
            if (movementKeyDown)
            {
                anim.SetTrigger("LandAndMove");
            }
            else
            {
                anim.SetTrigger("Stop");
            }
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        ResetValues();

        Debug.Log(Input.GetAxis("Horizontal"));
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
        if (Input.GetKeyDown(KeyCode.Space))
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
