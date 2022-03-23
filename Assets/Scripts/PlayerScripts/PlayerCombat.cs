using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int mag;
    public int totalPistolAmmo = 21;
    public int totalRifleAmmo = 90;
    public int totalRocketAmmo = 5;

    private int _equippedWeaponTotalAmmo;

    public int EquippedWeaponTotalAmmo
    {
        get
        {
            switch (equippedWeapon.weaponName)
            {
                case "Pistol":
                    return totalPistolAmmo;
                case "Assault Rifle":
                    return totalRifleAmmo;
                case "Rocket Launcher":
                    return totalRocketAmmo;
                default:
                    return -1;
            }
        }
        set
        {
            switch (equippedWeapon.weaponName)
            {
                case "Pistol":
                    totalPistolAmmo = value;
                    break;
                case "Assault Rifle":
                    totalRifleAmmo = value;
                    break;
                case "Rocket Launcher":
                    totalRocketAmmo = value;
                    break;
            }
        }
    }


    public float fireRateMultiplier = 1f;
    public float damageMultiplier = 1f;
    public float bulletSpeedMultiplier = 1f;
    public Weapon equippedWeapon;
    private bool onCooldown;

    private PlayerMovement playerMovement;
    private Animator animator;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        mag = equippedWeapon.magSize;
        onCooldown = false;
    }
    private void Update()
    {
        if(Input.GetButton("Fire1") && !onCooldown)
        {
            if(!MagEmpty())
            {
                Shoot();
                mag--;
                animator.SetTrigger("Shoot");
                StartCoroutine(Cooldown());
                EventManager.Instance.RaiseOnPlayerShoot();
            }
        }
        if(Input.GetButtonDown("Reload"))
        {
            Reload();
            EventManager.Instance.RaiseOnPlayerReload();
        }
    }

    private void Shoot()
    {
        equippedWeapon.Shoot(gameObject, damageMultiplier, bulletSpeedMultiplier, playerMovement.facing);
    }
    public IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(1 / (equippedWeapon.fireRate * fireRateMultiplier));
        onCooldown = false;
    }
    private bool MagEmpty()
    {
        if (mag <= 0)
            return true;
        else
            return false;
    }
    private void Reload()
    {
        if (EquippedWeaponTotalAmmo >= equippedWeapon.magSize - mag)
        {
            EquippedWeaponTotalAmmo -= equippedWeapon.magSize - mag;
            mag = equippedWeapon.magSize;
        }
        else
        {
            mag += EquippedWeaponTotalAmmo;
            EquippedWeaponTotalAmmo = 0;
        }
    }
}
