using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehavior {

public CharacterController2D controller;

public float runSpeed = 5f; //default player running speed

float horizontalMove = 2f; //default player movement
//Update occurs once per frame 

void Update () {
	
	horizontalMove = Input.GetAxisRaw("Horizontal");
	
  if (Input.GetButtonDown("Backward"))
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

	if (Input.GetButtonDown("Crouch");
	{
	  crouch = true;
	}

	else if (Input.GetButtonUp("Crouch");
	{
		crouch = false;
	}
 }

void FixedUpdate ()
{
	controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
	jump = false;
	
	}
}	
