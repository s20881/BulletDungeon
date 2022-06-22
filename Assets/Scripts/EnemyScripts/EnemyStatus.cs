using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private string type;
    [SerializeField] private float initialHealth = 100f;
    private float maxHealth;
    private float currentHealth;
    [SerializeField] private float damageReceivedMultiplier = 1f;
    [SerializeField] private bool invincible = false;
    [SerializeField] private GameObject healthBarPrefab;
    private GameObject worldSpaceCanvas;
    [SerializeField] GameData gameData;
    public GameObject scrapDrop;
    public GameObject gelDrop;
    public GameObject mediGelDrop;

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
        int rand = Random.Range(1, 6);
        if (type == "Drone")
            EventManager.Instance.RaiseOnDroneDeath();
        else if (type == "Robot")
            EventManager.Instance.RaiseOnRobotDeath();
        GetComponent<Animator>().SetTrigger("Death");
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(this);


        switch (rand)
        {
            case 4:
                Instantiate(scrapDrop, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(gelDrop, transform.position, Quaternion.identity);
                break;
            case 6:
                Instantiate(mediGelDrop, transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
        
    }
}
