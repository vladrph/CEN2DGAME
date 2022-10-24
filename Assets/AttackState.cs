//Specific Purpose: Defines the AttackState for the Zombie 2D asset and its states: OnStateEnter, OnStateUpdate, and OnStateExit

using Systems.Collections.Generic;
using Systems.Collections;
using UnityEngine;

public class AttackState: StateMachineBehavior
{
    Transform target;
    Transform borderCheck;

override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
    
    target = GameObject.FindGameObjectWithTag("Player").transform;
}

override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    
    float distance = Vector2.Distance(target.position, animator.transform.position);
    if (distance > 2) {
        animator.setBool("isAttacking",false);
    }
}

override public void OnStateExit (Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //utilized for playing audio 
    //AudioManage.instance.Play("ZombieScream");
}

// Note: AttackState and ChaseState are directly related behaviors (AttackState -> ChaseState, ChaseState -> AttackState)
}
