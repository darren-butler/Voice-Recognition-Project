using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if(fsmController.targetAlien.GetComponent<Movement>().isHidden == false)
        {
            if (Vector3.Distance(animator.transform.position, fsmController.targetAlien.transform.position) <= fsmController.killRange)
            {
                fsmController.targetAlien.SetActive(false);
                animator.SetTrigger("Reset");
            }
            else
            {
                animator.transform.position = Vector3.MoveTowards(animator.transform.position, fsmController.targetAlien.transform.position, fsmController.speed * Time.deltaTime);
            }
        }
        else
        {
            animator.SetTrigger("Reset");
        }


    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        animator.ResetTrigger("Reset");
    }
}
