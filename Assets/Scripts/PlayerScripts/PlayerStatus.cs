using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Range(0f, 100f)] public float currentHp = 100f;
    public float maxHp = 100f;
    public float damageReceivedMultiplier = 1f;
    [SerializeField] private bool invincible = false;

    public void PlayerHit(float damage)
    {
        if(!invincible)
            currentHp -= damage * damageReceivedMultiplier;
        if (currentHp <= 0)
            PlayerKilled();
    }
    public void PlayerKilled()
    {
        Debug.Log("Player killed");
        GameObject.Destroy(gameObject);
    }
}
