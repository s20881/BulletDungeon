using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float fireRateMultiplier = 1f;
    public float damageMultiplier = 1f;
    public float bulletSpeedMultiplier = 1f;
    public Weapon weapon;
    private bool onCooldown;

    private void Start()
    {
        onCooldown = false;
    }
    private void Update()
    {
        if(Input.GetButton("Fire1") && !onCooldown)
        {
            Shoot();
            StartCoroutine(Cooldown());
        }
    }

    private void Shoot()
    {
        weapon.Shoot(transform, damageMultiplier, bulletSpeedMultiplier);
    }
    public IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(1 / (weapon.fireRate * fireRateMultiplier));
        onCooldown = false;
    }
}
