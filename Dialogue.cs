using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    //Indicator
    public GameObject indicator;
    //Dialogues list
    public List<string> dialogues;
    //Text component
    public TMP_Text dialogueText;
    //Index on dialogue
    private int index;
    //Character index
    private int charIndex;
    //Started boolean
    private bool started;
    //writing speed
    public float writingSpeed;
    //wait for new boolean
    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //Start Dialogue
    public void StartDialogue()
    {

        if (started)
            return;

        //Boolean to indicate we have started
        started = true;
        //show the window
        ToggleWindow(true);
        //hide the indicator
        ToggleIndicator(false);
        //Start with dialogue 0
        GetDialogue(0);
    }

    //Get Dialogue
    private void GetDialogue(int i)
    {
        //start index at zero
        index = i;
        //reset the character index
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //start writing
        StartCoroutine(Writing());
    }

    //End dialogue
    public void EndDialogue()
    {
        //Start is disabled
        started = false;
        //Disable for next also disabled
        waitForNext = false;
        StopAllCoroutines();
        //Hide the window
        ToggleWindow(false);
    }

    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        //Write the char
        dialogueText.text += currentDialogue[charIndex];
        //Increase char index
        ++charIndex;
        //Check if end reached
        if(charIndex < currentDialogue.Length)
        {
            //Wait x seconds 
            yield return new WaitForSeconds(writingSpeed);
            //Restart process
            StartCoroutine(Writing());
        }
        
        else
        {
            //end sentence 
            waitForNext = true;
        }
    }

    private void Update()
    {
        if (!started)
            return;

        if(waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            if(index < dialogues.Count)
            {
                //Fetch the next dialogue
                GetDialogue(index);
            }
            else
            {
                //End the dialogue process
                ToggleIndicator(true);
                EndDialogue();
   
            }
        }
    }
}
