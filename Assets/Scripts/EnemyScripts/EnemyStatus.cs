using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    [SerializeField] private float damageReceivedMultiplier = 1f;
    [SerializeField] private bool invincible = false;
    [SerializeField] private GameObject healthBarPrefab;
    private GameObject worldSpaceCanvas;

    private void Start()
    {
        Transform worldSpaceCanvas = GameObject.Find("WorldSpaceCanvas").transform;
        GameObject healthBar = Instantiate(healthBarPrefab, worldSpaceCanvas);
        healthBar.GetComponent<EnemyHealthBar>().enemy = this;
    }
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
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(this);
    }
}
