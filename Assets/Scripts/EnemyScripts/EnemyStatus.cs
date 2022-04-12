using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth = 100f;
    [SerializeField] private float damageReceivedMultiplier = 1f;
    [SerializeField] private bool invincible = false;

    public void Hit(float damage)
    {
        EventManager.Instance.RaiseOnDroneHit();
        if(!invincible)
        {
            currentHealth -= damage * damageReceivedMultiplier;
            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }
    [ContextMenu("Kill")] public void Death()
    {
        EventManager.Instance.RaiseOnDroneDeath();
        GetComponent<Animator>().SetTrigger("Death");
        Destroy(this);
    }
}
