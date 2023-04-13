using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TriggerSFX : MonoBehaviour
{

    public AudioSource playSound;
    
    private string SKELETON_TAG = "Skeleton";

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Skeleton")
        {
            playSound.Play(); 
            Debugging.Log("Player collided with skeleton");
        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        EnemySpawn enemy = new EnemySpawn();
        
        if (col.gameObject.tag == "Skeleton")
        {
            playSound.Play();
        }
    }
}
