using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHitState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        EventManager.Instance.RaiseOnDroneHit();
    }
}
