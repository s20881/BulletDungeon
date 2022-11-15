using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    public float damageMultiplier = 1f;
    [SerializeField] private float attackSpeed = 1f;
    public float attackSpeedMultiplier = 1f;
    private bool onCooldown;

    public bool OnCooldown { get { return onCooldown; } }

    private PlayerStatus player;
    private Animator animator;

    private void Start()
    {
        onCooldown = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (player ?? false)
            if (!OnCooldown)
        {
            player.Hit(damage * damageMultiplier);
            animator.SetTrigger("Attack");
            EventManager.Instance.RaiseOnRobotAttack();
            StartCoroutine(Cooldown());
        }
    }
    public IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(1 / attackSpeed);
        onCooldown = false;
    }
}
