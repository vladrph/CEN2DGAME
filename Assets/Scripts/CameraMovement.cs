 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class CameraMovement : MonoBehaviour
 {

     private Transform player;

     private Vector3 tempPos;
     [SerializeField] private float minX;
     [SerializeField] private float maxxX;
    
     // Start is called before the first frame update
     void Start()
     {
         player = GameObject.FindWithTag("Player").transform;
     }

     // Update is called once per frame
     void LateUpdate()
     {
         if (player == null)
             return;
         
         tempPos = transform.position;  // stores current value of Current position of Camera 
         tempPos.x = player.position.x;  // This is the player's current posiiton 

         transform.position = tempPos; // Camera follows player's position
     }
 }
