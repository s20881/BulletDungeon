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

    private void Start()
    {
        onCooldown = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }

    public void Attack()
    {
        player.Hit(damage * damageMultiplier);
        EventManager.Instance.RaiseOnRobotAttack();

    }
    public IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(1 / attackSpeed);
        onCooldown = false;
    }
}
