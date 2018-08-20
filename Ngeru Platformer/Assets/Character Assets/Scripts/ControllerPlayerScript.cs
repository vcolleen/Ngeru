using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerScript : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    public float movementSpeed;

    public Transform[] groundPoints;

    public float groundRadius;

    private bool isGrounded;
    private bool jump;

    public float jumpForce;

    public LayerMask whatIsGround;

    public bool movementKeyDown = false;
    public bool isJumping = false;

    public float startIdle;
    public float waitTime;
    public bool isIdle;

    bool isLayingDown;



    //calling the animator
    Animator anim;


    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

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

    void Update()
    {
        HandleInput();

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


        
        if (movementKeyDown == false) 
        {
            if (isJumping == false)
            {
                if (isIdle == false)
                {
                    startIdle = (Time.time + waitTime);
                    Debug.Log("Start Idle");
                    isIdle = true;
                }


            }
        }

        if (isLayingDown == false)
        {
            if (Time.time > startIdle)
            {
                if (isIdle == true)
                {
                    anim.SetTrigger("LayDown");
                    Debug.Log("Lay Down");
                }

            }
        }


       


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        ResetValues();
    }

    /*
    private void IdleAnimations() {
        if (isIdle == true) {
            anim.SetBool("IsIdle", true);
            StartCoroutine(Idle());
            StartCoroutine(IdleLie());
            StartCoroutine(IdleReturn());
        }

        else
        {
            anim.SetBool("IsIdle", false);
        }
    }

    IEnumerator IdleLie()
    {
        yield return new WaitForSeconds(5);
        anim.SetInteger("State", 4);
        StopCoroutine(IdleLie());
    }

    IEnumerator Idle()
    {
        yield return new WaitForSeconds(3);
        anim.SetInteger("State", 3);
        StopCoroutine(Idle());
    }

    IEnumerator IdleReturn()
    {
        yield return new WaitForSeconds(10);
        anim.SetInteger("State", 5);
        StopCoroutine(IdleReturn());
    }
    */

    private void HandleMovement(float horizontal)
    {

        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, jumpForce));

        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

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
