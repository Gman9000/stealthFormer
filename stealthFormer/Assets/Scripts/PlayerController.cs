using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private LevelManager theLevelManager;

    //Moving the player
    public Rigidbody2D myRigidBody;
    public float moveSpeed;

    public KeyCode left;
    public KeyCode right;

    //Jump checking
    public KeyCode jump;
    public Transform groundCheck;
    public float groundCheckradius;
    public LayerMask WhatIsGround;
    public bool isGrounded;
    public float jumpSpeed;
    private bool doublejump;

    /*//Snowball Throw
    public KeyCode throwSnowBall;
    public GameObject snowBall;
    public Transform throwPoint;
    public float throwSnowBallCooldown;
    private float snowBallcounter;
    code from a past game that allows you to shoot. will implement later
    */

    //Animation
    private Animator myAnimator;

    // sound effects
    public AudioSource throwSnowballSound;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        theLevelManager = FindObjectOfType<LevelManager>();
        doublejump = false;

    }

    // Update is called once per frame
    void Update()
    {
        //snowBallcounter -= Time.deltaTime;

        //JumpSetup
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckradius, WhatIsGround);

        //Moving the Player
        if (Input.GetKey(right))
        {
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetKey(left))
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
        }

        //JumpCheck
        if (Input.GetKeyDown(jump))
        {
            if (isGrounded)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
                doublejump = true;
            }
            else
            {
                if (doublejump)
                {
                    myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
                    doublejump = false;
                }
            }
            
        }
        // doublejump is only true if you are already off the ground
        
           
        

        /*//Throwing Snowball
        if (Input.GetKeyDown(throwSnowBall) && snowBallcounter <= 0)
        {
            GameObject ballClone = (GameObject)Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            throwSnowballSound.Play();
            myAnimator.SetTrigger("Throw");
            snowBallcounter = throwSnowBallCooldown;
        }
        */
        myAnimator.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
        myAnimator.SetBool("Grounded", isGrounded);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Enemy")||(other.gameObject.tag == "leftwallkillzone") || (other.gameObject.tag == "rightwallkillzone") || (other.gameObject.tag == "ceilingkillzone") || (other.gameObject.tag == "floorkillzone"))
        {
            theLevelManager.GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            theLevelManager.GameOver();
        }
    }


}

