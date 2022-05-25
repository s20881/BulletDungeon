using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private string type;
    private float initialHealth = 100f;
    private float maxHealth;
    private float currentHealth;
    [SerializeField] private float damageReceivedMultiplier = 1f;
    [SerializeField] private bool invincible = false;
    [SerializeField] private GameObject healthBarPrefab;
    private GameObject worldSpaceCanvas;
    [SerializeField] GameData gameData;

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
            if (maxHealth < CurrentHealth)
                CurrentHealth = maxHealth;
        }
    }
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }
    }

    private void Start()
    {
        currentHealth = initialHealth;
        maxHealth = initialHealth;
        Transform worldSpaceCanvas = GameObject.Find("WorldSpaceCanvas").transform;
        GameObject healthBar = Instantiate(healthBarPrefab, worldSpaceCanvas);
        healthBar.GetComponent<EnemyHealthBar>().enemy = this;
        damageReceivedMultiplier = gameData.levelenem;
    }
    public void Hit(float damage)
    {
        if (type == "Drone")
            EventManager.Instance.RaiseOnDroneHit();
        else if (type == "Robot")
            EventManager.Instance.RaiseOnRobotHit();
        if(!invincible)
        {
            CurrentHealth -= damage * damageReceivedMultiplier;
            if (CurrentHealth <= 0)
            {
                Death();
            }
        }
    }
    [ContextMenu("Kill")] public void Death()
    {
        if (type == "Drone")
            EventManager.Instance.RaiseOnDroneDeath();
        else if (type == "Robot")
            EventManager.Instance.RaiseOnRobotDeath();
        GetComponent<Animator>().SetTrigger("Death");
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(this);
    }
}
