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


    //calling the animator
    Animator anim;

    //bool isIdle;


    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        HandleInput();

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetInteger("State", 2);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetInteger("State", 1);
        }


        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State", 0);
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
