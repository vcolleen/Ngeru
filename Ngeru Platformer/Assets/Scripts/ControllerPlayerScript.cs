using System.Collections;
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
    private bool isGrounded;
    private bool jump;
    public float jumpForce;
    public LayerMask whatIsGround;

    //Movement Variables 
    private bool isIdle;
    private bool isWalkingRight;
    private bool isWalkingLeft;
    private bool isTurningRight;
    private bool isTurningLeft;
    private bool isRunning;
    private bool CanTurnLeft;
    private bool CanTurnRight;
    private bool landing;

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

    /*AI Variables 
    public bool isHiding;
    public GameObject hidingController;
    */

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        anim.SetBool("isWalkingRight", true);

        isWaitingForSuperIdle = true;
        isWaitingForIdle = true;
        isIdle = true;
        CanTurnRight = true;
    }




    void Update()
    {
        //Jump-Movement 
        HandleInput();

        //Debug.Log(Input.GetAxis("Jump"));


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
            jumpForce = 250;
        }

        if (isRunning == false)
        {
            anim.SetBool("isRunning", false);
            movementSpeed = 0.8f;
            jumpForce = 220;
        }

        Debug.Log(Input.GetAxis("Horizontal"));

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
        if (isIdle)
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
                IdleLayer();
                anim.SetBool("isLayingDown", true);
                isSitting = true;
            }
            if (Time.time > startSitting)
            {
                anim.SetBool("isSuperIdle", true);
            }

            else
            {
                anim.SetLayerWeight(3, 0);
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
        if(myRigidBody.velocity.y < 0)
        {
            landing = true;
            anim.SetBool("Landing", true);

        }

        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        if (isGrounded && jump)
        {
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
        if (Input.GetAxis("Jump") >= 1)
        {
            jump = true;
        }
        //Hiding();
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
            anim.SetLayerWeight(2, 1);
            anim.SetLayerWeight(1, 0);
        }

        else
        {
            anim.SetLayerWeight(2, 0);
            anim.SetLayerWeight(1, 1);
        }
    }

    private void IdleLayer()
    {
        anim.SetLayerWeight(3, 1);
    }

   

    /*private void Hiding()
    {
        if (Input.GetAxis("Hide") == 1)
        {
            hidingController.GetComponent<HiddenArrayScript>().CheckHiding();
            if (hidingController.GetComponent<HiddenArrayScript>().canHideObject.GetComponent<HiddenObjectScript>().isOverlaping == true)
            {
                gameObject.layer = 2;
                isHiding = true;
                gameObject.transform.position = hidingController.GetComponent<HiddenArrayScript>().canHideObject.transform.position;
            }
        }
        if (Input.GetAxis("Hide") == 0)
        {
            gameObject.layer = 10;
            isHiding = false;
        }
    }
    */


}
