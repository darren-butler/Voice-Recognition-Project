using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    private Vector3 target;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        target = fsmController.patrolPoints[0];
        fsmController.patrolPauseTimer = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if(Vector3.Distance(animator.transform.position, target) <= 0f)
        {
            if(fsmController.patrolPauseTimer <= 0)
            {
                target = fsmController.patrolPoints[Random.Range(0, fsmController.patrolPoints.Count)];
                fsmController.patrolPauseTimer = fsmController.patrolPauseTime;

            }
            else
            {
                fsmController.patrolPauseTimer -= Time.deltaTime;
            }
        }
        
        
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, fsmController.speed * Time.deltaTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.ResetTrigger("aggro");
    }
}
