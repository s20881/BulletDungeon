using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour
{
    [SerializeField] private float initialHealth = 100f;
    public float damageReceivedMultiplier = 1f;
    [SerializeField] private bool invincible = false;
    private Animator animator;

    public GameObject gelPrefab;
    public GameObject scrapPrefab;

    private float _currentHealth;
    private float _maxHealth;

    const float gelDropChance = 3f / 10f, scrapDropChance = 7f / 10f, overallDropChance = 2f / 10f;
    public float CurrentHealth
    {
        get { return _currentHealth; }
    }
    public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
            if(_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        _currentHealth = initialHealth;
        _maxHealth = initialHealth;
    }

    public void Hit(float damage)
    {
        if (!invincible)
        {
            animator.SetTrigger("Hit");
            _currentHealth -= damage * damageReceivedMultiplier;
            if (_currentHealth <= 0)
            {
                Death();
                itemDrop();
            }
        }
    }
    public void Heal(float healthPoints)
    {
        _currentHealth += healthPoints;
        if (CurrentHealth > MaxHealth)
            _currentHealth = MaxHealth;
    }
    private void Death()
    {
        animator.SetTrigger("Death");
    }
    private void itemDrop()
    {
        float a = Random.Range(0f, 1f);
        if (a <= overallDropChance)
        {
            if (a <= gelDropChance)
            {
                Instantiate(gelPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(scrapPrefab, this.gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
