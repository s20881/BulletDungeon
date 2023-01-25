using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour
{
    [SerializeField] public float initialHealth = 100f;
    public float damageReceivedMultiplier = 1f;
    [SerializeField] private bool invincible = false;
    private Animator animator;
    [SerializeField] public PlayerItems items;

    private float _currentHealth;
    private float _maxHealth;

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
            }
        }
    }
    public void Heal(float healthPoints)
    {
        _currentHealth += healthPoints;
        if (CurrentHealth > MaxHealth)
            _currentHealth = MaxHealth;
    }
    public void upgradeHealth()
    {
        if(initialHealth <= 175f)
        {
            initialHealth += 5f;
            items.scrap -= 25;
            items.gel -= 75;
        }
    }
    public void upgradeArmor()
    {
        if(damageReceivedMultiplier > 0.75f)
        {
            damageReceivedMultiplier -= 0.05f;
            items.scrap -= 50;
            items.gel -= 150;
        }
    }
    private void Death()
    {
        animator.SetTrigger("Death");
    }
}
