﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashEnemyCombatState : StateMachineBehaviour {
    EnemyTrash enemyTrash;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(enemyTrash == null)
        {
            enemyTrash = animator.transform.gameObject.GetComponent<EnemyTrash>();
        }
        enemyTrash.DisableSwordEmitter();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyTrash != null && enemyTrash.GetTarget() != null && enemyTrash.GetTarget().type == TargetType.TT_PLAYER)
        {
            Vector3 direction = enemyTrash.GetTarget().transf.position - enemyTrash.transform.position;
            
            // Cast ray to target in combat range
            RaycastHit hitC;
            bool combatRayHit = Physics.Raycast(enemyTrash.transform.position, direction, out hitC, enemyTrash.combatRange);

            // Cast ray to target in attack range
            RaycastHit hitA;
            bool attackRayHit = Physics.Raycast(enemyTrash.transform.position, direction, out hitA, enemyTrash.attackRange);

            // Debug draw combat ray
            Color rayColor;
            rayColor = combatRayHit ? Color.green : Color.red;
            Debug.DrawRay(enemyTrash.transform.position, direction, rayColor);

            bool change = true;
            if (!combatRayHit)
            {
                animator.SetTrigger("chase");
            }
            else if (combatRayHit && !attackRayHit)
            {
                enemyTrash.nav.Stop();
                animator.SetTrigger("moveAround");
            }
            else if (attackRayHit)
            {
                enemyTrash.nav.Stop();
                animator.SetTrigger("attack");
            }
            else
            {
                change = false;
            }

            if(change)
                animator.SetBool("combat", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}