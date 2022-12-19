using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EventManager.Instance.RaiseOnBossHit();
        Debug.Log("Boss hit");
    }
}
