using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class ControllerPlayerScript : MonoBehaviour
{
=======
public class ControllerPlayerScript : MonoBehaviour {
>>>>>>> parent of 9be2bfd... Merge

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

<<<<<<< HEAD
    public float timeBetweenJumps;
    float nextJump;

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
=======
    //Movement Variables 
    public bool isIdle;
    public bool isWalkingRight;
    public bool isWalkingLeft;
    public bool isTurningRight;
    public bool isTurningLeft;
    public bool isJumping;
    public bool isRunning;
>>>>>>> parent of 9be2bfd... Merge


    //calling the animator
    Animator anim;

<<<<<<< HEAD
    //AI Variables 
    public bool isHiding;
    private bool isOverlaping = false;

    public Vector2 previousPosition;
    private Transform player;

=======
>>>>>>> parent of 9be2bfd... Merge
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
<<<<<<< HEAD
        anim.SetBool("isWalkingRight", true);

        isWaitingForSuperIdle = true;
        isWaitingForIdle = true;
        isIdle = true;
        CanTurnRight = true;

        player = GameObject.FindGameObjectWithTag("Player").transform;
=======

        anim.SetTrigger("isLookingRight");

        isIdle = true;
        isWalkingRight = false;
        isWalkingLeft = false;
        isTurningRight = false;
        isTurningLeft = false;
        isJumping = false;
        isRunning = false;
>>>>>>> parent of 9be2bfd... Merge
    }



<<<<<<< HEAD

=======
>>>>>>> parent of 9be2bfd... Merge
    void Update()
    {
        //Jump-Movement 
        HandleInput();

<<<<<<< HEAD

        //Animations & Keyboard Triggers 
        //Idle
        if ((Input.GetAxis("Horizontal") == 0))
=======
//        Debug.Log(Input.GetAxis("Jump"));


        //Animations & Keyboard Triggers 
        //Idle
        if (Input.GetAxis("Horizontal") == 0)
>>>>>>> parent of 9be2bfd... Merge
        {
            anim.SetBool("isIdle", true);
        }

        else
        {
            anim.SetBool("isIdle", false);
        }

        //Run
<<<<<<< HEAD
        if (Input.GetAxis("Run") > 0)
=======
        if(Input.GetAxis("Run") > 0)
>>>>>>> parent of 9be2bfd... Merge
        {
            isRunning = true;
        }

        else
        {
            isRunning = false;
        }

<<<<<<< HEAD
        if (isRunning == true)
=======
        if(isRunning == true)
>>>>>>> parent of 9be2bfd... Merge
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", false);
            movementSpeed = 2f;
<<<<<<< HEAD
            jumpForce = 300;
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
=======
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
>>>>>>> parent of 9be2bfd... Merge
        }

        else
        {
            isWalkingRight = false;
        }

<<<<<<< HEAD
        if (isWalkingRight == true)
        {
            anim.SetBool("isWalkingRight", true);
            anim.SetBool("CanTurnRight", true);
            anim.SetBool("CanTurnLeft", false);
=======
        if(isWalkingRight == true)
        {
            anim.SetBool("isWalkingRight", true);
>>>>>>> parent of 9be2bfd... Merge
        }

        if (isWalkingRight == false)
        {
            anim.SetBool("isWalkingRight", false);
<<<<<<< HEAD
           
        }

        //WalkingLeft 
        if (Input.GetAxis("Horizontal") < 0)
        {
            isWalkingLeft = true;
            isWalkingRight = false;
            anim.SetTrigger("Turn");
=======
        }

        //WalkingLeft 
        if(Input.GetAxis("Horizontal") < 0)
        {
            isWalkingLeft = true;
            anim.SetTrigger("isLookingLeft");
>>>>>>> parent of 9be2bfd... Merge
        }
        else
        {
            isWalkingLeft = false;
        }

<<<<<<< HEAD
        if (isWalkingLeft == true)
        {
            anim.SetBool("isWalkingLeft", true);
            anim.SetBool("CanTurnLeft", true);
            anim.SetBool("CanTurnRight", false);
=======
        if(isWalkingLeft == true)
        {
            anim.SetBool("isWalkingLeft", true);
>>>>>>> parent of 9be2bfd... Merge
        }

        if (isWalkingLeft == false)
        {
<<<<<<< HEAD
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
                anim.SetLayerWeight(2, 1);
                anim.SetBool("isLayingDown", true);
                isSitting = true;
            }
            if (Time.time > startSitting)
            {
                anim.SetBool("isSuperIdle", true);
            }
        }
    


=======
            anim.SetBool("isWalkingLeft", false);

        }
>>>>>>> parent of 9be2bfd... Merge


    }


    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);

<<<<<<< HEAD
        HandleLayers();

=======
>>>>>>> parent of 9be2bfd... Merge
        ResetValues();
    }


    //Left to right movement
    private void HandleMovement(float horizontal)
    {
<<<<<<< HEAD
        if(myRigidBody.velocity.y < 0)
        {
            landing = true;
            anim.SetBool("Landing", true);

        }
=======
>>>>>>> parent of 9be2bfd... Merge

        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);

        if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, jumpForce));
<<<<<<< HEAD
            anim.SetBool("isIdle", false);
            anim.SetBool("isLayingDown", false);
            anim.SetBool("isSuperIdle", false);
            anim.SetTrigger("Jump");
        }
    }


=======
            anim.SetBool("isJumping", true);
        }

        if(isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
    }

    
>>>>>>> parent of 9be2bfd... Merge

    //Jump
    private void HandleInput()
    {
<<<<<<< HEAD
        if (Input.GetAxis("Jump") >= 1 && Time.time > nextJump)
        {
            jump = true;
            isIdle = false;
            isSitting = false;
            isWaitingForIdle = true;
            nextJump = (Time.time + timeBetweenJumps);
        }

        if (Input.GetAxis("Trigger") == 0) {
            Hiding();
=======
        if (Input.GetAxis("Jump") >= 1)
        {
            jump = true;
            anim.SetBool("isIdle", false);
>>>>>>> parent of 9be2bfd... Merge
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
<<<<<<< HEAD
                        anim.ResetTrigger("Jump");
                        anim.SetBool("Landing", false);
=======
>>>>>>> parent of 9be2bfd... Merge
                        return true;
                    }

                }
<<<<<<< HEAD

            }

=======
                
            }
            
>>>>>>> parent of 9be2bfd... Merge
        }
        return false;
    }

    private void ResetValues()
    {
        jump = false;
    }

<<<<<<< HEAD
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
                gameObject.transform.position = GameObject.Find("HidingCouch").transform.position;
                previousPosition = gameObject.transform.position;
                Debug.Log("isHiding");
            }

            if (isHiding == true)
            {
                anim.SetBool("isHiding", true);
                anim.SetBool("isIdle", false);
            }
        }
        if (Input.GetAxis("Hide") == 0)
        {
            isHiding = false;
            previousPosition = player.transform.position;
            gameObject.layer = 10;
            Debug.Log("isn'tHiding");
        }

        if (isHiding == false)
        {
            anim.SetBool("isHiding", false);
            anim.SetBool("isIdle", true);
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

=======
   
>>>>>>> parent of 9be2bfd... Merge
}
