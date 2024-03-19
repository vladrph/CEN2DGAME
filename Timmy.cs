//This script contains fixtures to the jumping movement, ground check, DestroyOnLoad instances of the player
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
//public CharacterController2D controller;

    float horizontalMove = 2f; //default player movement
    private float verticalMove = 2f; // vertical player movement
    public float runSpeed = 5f; //default player running speed
    const float groundCheckRadius = 0.2f;
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpPower = 30f;
    [SerializeField] int totalJumps;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    private float movementX;
    private float movementY;
    private float rotationZ;

    public Rigidbody2D mybody;

    private SpriteRenderer sr;
    private Transform trans;

    private Animator anim;
    private bool IsGrounded;
    private string WALK_ANIMATION = "walk";
    private string IDLE_ANIMATION = "Idle";
    private string JUMP_ANIMATION = "jump";

    private bool isGrounded = true;
    private bool isJumping;
    private bool multipleJump;
    private int availableJumps;
    private bool isDead = false;


    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Zombie";

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    private void Awake()
    {
        //mybody.AddForce(new Vector2(2,2));
        mybody = GetComponent<Rigidbody2D>(); // attaching the object to the attributes 
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();

        availableJumps = totalJumps;
    }


//Update occurs once per frame

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal"); // used to go left or right 
        verticalMove = Input.GetAxisRaw("Vertical");

        Vector2 pos = transform.position;
        pos.x += horizontalMove * runSpeed * Time.deltaTime;
        pos.y += verticalMove * runSpeed * Time.deltaTime; // time between every frame 

        transform.position = pos;

        if (Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }

        PlayerMoveKeyboard();
        //AnimatePlayer();
       
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        Debug.Log("move x value is: " + movementX);
        Debug.Log("Movement y value is: " + movementY);
       // transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        transform.position += new Vector3(movementX, movementY, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            // right side movement 


            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false; // This allows us to flip the direction that the user is facing 
        }
        else if (movementX < 0)
        {
            //left side movement 


            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true; // This allows us to flip the direction that the user is facing 
        }

        else if (movementX == 0)
        {
            anim.SetBool(IDLE_ANIMATION, true);
        }

        else if( movementY > 0)
        {
         anim.SetBool(JUMP_ANIMATION,true);   
        }
        else

        {
           anim.SetBool(WALK_ANIMATION, false);
            sr.flipX = false;
                // anim.SetBool(IDLE_ANIMATION, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            if (!wasGrounded)
            {
                availableJumps = totalJumps;
                multipleJump = false;
            }
        }
    }

    void PlayerJump()
    {
        if (isGrounded)
        {
            multipleJump = true;
            availableJumps--;

            mybody.velocity = Vector2.up * jumpPower;
            anim.SetBool(JUMP_ANIMATION, true);
        }
        else
        {
            if (multipleJump && availableJumps > 0)
            {
                availableJumps--;

                mybody.velocity = Vector2.up * jumpPower;
                anim.SetBool(JUMP_ANIMATION, false);
            }
        }
    }

    void FixedUpdate()
    {
        AnimatePlayer();

        //controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        //jump = false;
    }


    private void Die()
    {
        isDead = true;
        FindObjectOfType<LevelManager>().Restart();
    }

    private void ResetPlayer()
    {
        isDead = false;
    }
}
