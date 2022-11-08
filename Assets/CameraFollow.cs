    
//This is the script called CameraFollow derived from the video "How to Make Camera Follow in Unity 2D"

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private Transform player;

    private Vector3 tempPos;
    [SerializeField] private float minX;
    [SerializeField] private float maxxX;
    //public float FollowSpeed = 2f;
   // public float yOffset = -1f;
    //public Transform target;

    private void Start()
    {
       
        player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate () 
    {
        tempPos = transform.position;  // stores current value of Current position of Camera 
        tempPos.x = player.position.x;  // This is the player's current posiiton 

        transform.position = tempPos;  // 
        
        // Camera follows player's position
        //Vector2 newPos = new Vector2(target.position.x, target.position.y + yOffset, -10f);
        //transform.position = Vector2(transform.position, newPos,FollowSpeed * Time.deltaTime);
    }
    
    
}

//Assign Target to "Player" for the camera to follow

