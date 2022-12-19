using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerMovement>().enabled = false;
        animator.GetComponent<PlayerCombat>().enabled = false;
        EventManager.Instance.RaiseOnPlayerDeath();
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}
