using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeState : StateMachineBehaviour
{
    [SerializeField] private float dodgeRange = 10f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyMovement>().currentDestination = animator.transform.position + (Vector3) Random.insideUnitCircle.normalized * dodgeRange;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyMovement>().currentDestination = animator.transform.position;
    }
}
