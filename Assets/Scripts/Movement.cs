
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour {

//public CharacterController2D controller;

float horizontalMove = 2f; //default player movement
private float verticalMove = 2f; // vertical player movement
public float runSpeed = 5f; //default player running speed
[SerializeField]
private float moveForce=10f;
[SerializeField]
private float jumpForce = 21f;

private float movementX;
private float rotationZ;

public Rigidbody2D mybody;

private SpriteRenderer sr;
private Transform trans;

private Animator anim;
private bool IsGrounded;
private string WALK_ANIMATION = "walk";
private string IDLE_ANIMATION = "Idle";

private bool isGrounded = true;

private string GROUND_TAG = "Ground";
private string ENEMY_TAG = "Zombie";

private void Awake()
{
	//mybody.AddForce(new Vector2(2,2));
	mybody = GetComponent<Rigidbody2D>();  // attaching the object to the attributes 
	anim = GetComponent<Animator>();
	sr = GetComponent<SpriteRenderer>();
	trans = GetComponent<Transform>();
}


//Update occurs once per frame

void Update () {
	
	horizontalMove = Input.GetAxisRaw("Horizontal");
	verticalMove = Input.GetAxisRaw("Vertical");  // used to go left or right 

	Vector2  pos = transform.position;
	pos.x += horizontalMove * runSpeed *Time.deltaTime;
	pos.y += verticalMove * runSpeed *Time.deltaTime;  // time between every frame 

	transform.position = pos;


	PlayerMoveKeyboard();
	AnimatePlayer();
	//PlayerJump();

	/*if (Input.GetButtonDown("Backward"))
	{
	    backward = true;
	}
	
	else if (Input.GetButtonUp("Backward"))
	{
	    backward = false;
	}
	
	  if (Input.GetButtonDown("Jump"))
	  {
		  jump = true;
	  }
  
  //	if (Input.GetButtonDown("Crouch")
	  {
		crouch = true;
	  }
  
  //	else if (Input.GetButtonUp("Crouch")
	  {
		  crouch = false;
	  }*/
}

void PlayerMoveKeyboard()
{
	movementX = Input.GetAxisRaw("Horizontal");
	Debug.Log("move x value is: " + movementX);

	transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

}

void AnimatePlayer()
{
	 

	 anim.SetBool(WALK_ANIMATION,true);
	

	if (movementX > 0 )
	{
		// right side movement 
		
		anim.SetBool(WALK_ANIMATION, true);
		sr.flipX = false;  // This allows us to flip the direction that the user is facing 
		//mybody.transform.localRotation.Set(0,0,0);
		//trans.rotation.Set(0, 0, 0);

	}
	else if (movementX< 0)
	{
		//left side movement 
		anim.SetBool(WALK_ANIMATION, true);
		sr.flipX = true; // This allows us to flip the direction that the user is facing 
	}
	else

	{
		anim.SetBool(WALK_ANIMATION, true);
		//anim.SetBool(IDLE_ANIMATION, true);
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

void FixedUpdate ()
{
	//controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
	//jump = false;
	
	}
}	
