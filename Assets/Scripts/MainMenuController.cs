using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public AudioSource playSound;
   public void PlayGame()
   {
      
     // playSound.Play();   
      Debug.Log("Button is pressed");
      SceneManager.LoadScene("Level 1");
      
   }
} //class
