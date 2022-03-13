using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float fireRateMultiplier = 1f;
    public float damageMultiplier = 1f;
    public float bulletSpeedMultiplier = 1f;
    public Weapon equippedWeapon;
    private bool onCooldown;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
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
        equippedWeapon.Shoot(transform, damageMultiplier, bulletSpeedMultiplier, playerMovement.facing);
    }
    public IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(1 / (equippedWeapon.fireRate * fireRateMultiplier));
        onCooldown = false;
    }
}
