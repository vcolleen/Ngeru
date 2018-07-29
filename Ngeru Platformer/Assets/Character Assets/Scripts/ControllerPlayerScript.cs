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



    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

        ResetValues();
    }


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
