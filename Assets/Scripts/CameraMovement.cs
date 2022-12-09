 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 public class CameraMovement : MonoBehaviour
 {

     private Transform player;

     private Vector3 tempPos;
     [SerializeField] private float minX;
     [SerializeField] private float maxxX;
     
     void Start()
     {
         player = GameObject.FindWithTag("Player").transform;
     }
     
     void LateUpdate()
     {
         if (player == null)
             return;
         
         tempPos = transform.position; 
         tempPos.x = player.position.x;  

         transform.position = tempPos; 
     }
 }
