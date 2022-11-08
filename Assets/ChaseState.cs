/*
//This is code based on the video 2D Zombie AI in Unity - State Machine Behaviors
//Specific Purpose: Used to control Zombie's chasing movement based on three states: OnStateEnter, OnStateUpdate, and OnStateExit.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehavior
{
    Transform target;
    Transform borderCheck;
    public float speed = 2;


override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    target = GameObject.FindGameObjectWithTag("Player").transform;
    borderCheck = animator.GetComponent<Zombie>().borderCheck;
}

override public void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    Vector2 newPos = new Vector2(target.position.x, animator.transform.position.y);
    animator.transform.position = Vector2.MoveTowards(animator.transform.position, newPos);
    if(Physics2D.Raycast(borderCheck.position, Vector2.down,2) == false) {
        animator.SetBool("isChasing", false);
    }
    
    if (distance < 1.5f) {
        animator.setBool("isAttacking", true);
    }
}

override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    
    }
    
  //ChaseState and AttackState are connected (ChaseState -> AttackState, AttackState -> ChaseState)
}
*/
