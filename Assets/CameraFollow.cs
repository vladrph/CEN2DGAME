//This is the script called CameraFollow derived from the video "How to Make Camera Follow in Unity 2D"

using System.Collections;
using Systems.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehavior
{
    public float FollowSpeed = 2f;
    public float yOffset = -1f;
    public Transform target;
    
    void update () 
    {
        Vector2 newPos = new Vector2(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector2(transform.position, newPos,FollowSpeed * Time.deltaTime);
    }
}

//Assign Target to "Player" for the camera to follow
