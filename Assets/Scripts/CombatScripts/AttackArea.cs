using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private EnemyMelee enemy;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyMelee>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!enemy.OnCooldown)
        {
            enemy.Attack();
            StartCoroutine(enemy.Cooldown());
        }
    }
}
