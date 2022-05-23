using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private Animator animator;
    private EnemyMelee enemy;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        enemy = GetComponentInParent<EnemyMelee>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!enemy.OnCooldown)
        {
            animator.SetTrigger("Attack");
            StartCoroutine(enemy.Cooldown());
        }
    }
}
