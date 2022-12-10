using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    private bool playerDetected; 

   //Detect trigger with player
   private void OnTriggerEnter2D(Collider2D collision)
    {
        //If we triggered the player enable PlayerDetected and show the indicator
        if(collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

   //If detected show indicator
  
   //If not detected, hide indicator
   private void OnTriggerExit2D(Collider2D collision)
    {
        //If no trigger detected, disable PlayerDetected and hide the indicator
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToggleIndicator(playerDetected);
        }
    }

   //While detected, if we interact start the dialogue
   private void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }
}
