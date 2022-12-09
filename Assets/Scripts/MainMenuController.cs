using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   public void PlayGame()
   {
      
      Debug.Log("Button is pressed");
      SceneManager.LoadScene("Level 1");
      
   }
} 
