/*
//This is based on code identified in the video 2D Zombie AI in Unity - State Machine Behaviors from tutorial GDTitans
//Specific Purpose: To define the Idle movement of the Zombie asset based on three states: OnStateEnter, OnStateUpdate, and OnStateExit

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IdleState : StateMachineBehaviour
{

    Transform target;
    public float speed = 2;
    Transform borderCheck;

//OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        target = GameObject.findGameObjectWithTag("Player").transform;
        borderCheck = animator.getComponent<Zombie>().borderCheck;
    }

//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
        {
            return;
        }

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 5)
        {
            animator.setBool("isChasing, true");
        }
    }

//OnStateExit is called when a transition ends and the state machine finishes evaulating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
//IdleState is the child behavior of Entry (Entry -> Idle)
*/