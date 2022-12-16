using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public bool hostile;
    private bool damageApplied = false;

    public void ApplyDamage()
    {
        if(!damageApplied)
        {
            if(!hostile)
            {
                int mask = LayerMask.GetMask("Enemy");
                Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius, mask);
                foreach (Collider2D enemy in hits)
                {
                    enemy.GetComponent<EnemyStatus>().Hit(damage);
                }
            }
            else
            {
                int mask = LayerMask.GetMask("Player");
                Collider2D player = Physics2D.OverlapCircle(transform.position, GetComponent<CircleCollider2D>().radius, mask);
                if(player != null)
                {
                    player.GetComponent<PlayerStatus>().Hit(damage);
                }
            }
            damageApplied = true;
        }
    }
}
