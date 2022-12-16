using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponSwitcher : StateMachineBehaviour
{
    [SerializeField] private Weapon weaponToEquip;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyShooting>().equippedWeapon = weaponToEquip;
    }
}
