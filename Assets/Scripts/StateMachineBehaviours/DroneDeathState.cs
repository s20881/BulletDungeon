using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDeathState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EventManager.Instance.RaiseOnDroneDeath();
        animator.GetComponent<EnemyMovement>().enabled = false;
        animator.GetComponent<EnemyShooting>().enabled = false;
        animator.GetComponent<CircleCollider2D>().enabled = false;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}
