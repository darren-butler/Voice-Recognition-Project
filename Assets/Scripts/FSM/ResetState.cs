using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetState : BaseState
{

    private Vector3 origin = new Vector3(0f,0f,0f);

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        Debug.Log("reset");
        if(Vector3.Distance(animator.transform.position, origin) <= 0f)
        {
            animator.SetTrigger("Patrol");
        }
        else
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, origin, fsmController.speed * Time.deltaTime);
        }

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.ResetTrigger("Patrol");
    }
}
