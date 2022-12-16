using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Range(0f, 100f)] public float currentHp = 100f;
    public float maxHp = 100f;
    public float damageReceivedMultiplier = 1f;
    [SerializeField] private bool invincible = false;
    [SerializeField] GameData gameData;
    void Start()
    {
        damageReceivedMultiplier = gameData.level;
    }
    public void Hit(float damage)
    {
        EventManager.Instance.RaiseOnPlayerHit();
        if(!invincible)
        {
            currentHp -= damage * damageReceivedMultiplier;
            if (currentHp <= 0)
            {
                Death();
            }
        }
    }
    [ContextMenu("Kill")] public void Death()
    {
        EventManager.Instance.RaiseOnPlayerDeath();
        GetComponent<Animator>().SetTrigger("Death");
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        Destroy(this);
        gameData.isDead = true;
    }
       
}
