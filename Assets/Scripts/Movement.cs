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
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 31;
    [SerializeField] int jumpPower;

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


    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Zombie";

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>(); // attaching the object to the attributes 
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
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


        PlayerMoveKeyboard();
        //AnimatePlayer();
       // PlayerJump();
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
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            IsGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonUp("Jump"))
        {
            mybody.AddForce (new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            anim.SetBool(JUMP_ANIMATION, true);
        }
        else
        {
            anim.SetBool(JUMP_ANIMATION, false);
        }
    }

    void FixedUpdate()
    {
        AnimatePlayer();
        PlayerJump();

        
    }
}