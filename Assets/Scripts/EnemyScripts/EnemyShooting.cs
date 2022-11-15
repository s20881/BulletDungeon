using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float fireRateMultiplier = 1f;
    public float damageMultiplier = 1f;
    public float bulletSpeedMultiplier = 1f;
    public Weapon equippedWeapon;
    private bool onCooldown;

    private GameObject player;

    private void Start()
    {
        onCooldown = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Shoot()
    {
        if (player ?? false)
            if (!onCooldown)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            equippedWeapon.Shoot(gameObject, damageMultiplier, bulletSpeedMultiplier, transform.position, direction);
            StartCoroutine(Cooldown());
            EventManager.Instance.RaiseOnDroneShoot();
        }
    }
    public IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(1 / (equippedWeapon.fireRate * fireRateMultiplier));
        onCooldown = false;
    }
}
