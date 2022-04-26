using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingState : StateMachineBehaviour
{
    private EnemyShooting enemy;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<EnemyShooting>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.Shoot();
    }
}
