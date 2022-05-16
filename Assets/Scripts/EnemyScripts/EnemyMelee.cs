using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    public float damageMultiplier = 1f;
    [SerializeField] private float attackRange = 1f;
    public float attackRangeMultiplier = 1f;
    [SerializeField] private float attackSpeed = 1f;
    public float attackSpeedMultiplier = 1f;
    private bool onCooldown;

    private PlayerStatus player;

    public float DistanceToPlayer
    {
        get
        {
            return Vector2.Distance(player.transform.position, transform.position);
        }
    }

    private void Start()
    {
        onCooldown = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();

    }
    private void Update()
    {
        Debug.Log(DistanceToPlayer);
        if (DistanceToPlayer <= attackRange * attackRangeMultiplier && !onCooldown)
        {
            Attack();
            StartCoroutine(Cooldown());
        }
    }

    private void Attack()
    {
        player.Hit(damage * damageMultiplier);
        EventManager.Instance.RaiseOnRobotAttack();

    }
    private IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(1 / attackSpeed);
        onCooldown = false;
        
    }
}
