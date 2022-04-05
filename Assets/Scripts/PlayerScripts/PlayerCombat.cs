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
    public float reloadSpeedMultiplier = 1f;
    public Weapon equippedWeapon;
    private bool onCooldown;
    public bool reloading;
    [SerializeField] private ReloadSlider slider;

    private PlayerMovement playerMovement;
    private Animator animator;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        mag = equippedWeapon.magSize;
        onCooldown = false;
        reloading = false;
    }
    private void Update()
    {
        if(Input.GetButton("Fire1") && !onCooldown && !reloading)
        {
            if(!MagEmpty())
            {
                Shoot();
                mag--;
                StartCoroutine(ShootingCooldown(1 / (equippedWeapon.fireRate * fireRateMultiplier)));
                EventManager.Instance.RaiseOnPlayerShoot();
            }
        }
        if(Input.GetButtonDown("Reload") && !reloading && mag < equippedWeapon.magSize)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    private void Shoot()
    {
        equippedWeapon.Shoot(gameObject, damageMultiplier, bulletSpeedMultiplier, playerMovement.facing);
    }
    public IEnumerator ShootingCooldown(float seconds)
    {
        onCooldown = true;
        yield return new WaitForSeconds(seconds);
        onCooldown = false;
    }
    private bool MagEmpty()
    {
        if (mag <= 0)
            return true;
        else
            return false;
    }
    private IEnumerator ReloadCoroutine()
    {
        reloading = true;
        slider.Play(equippedWeapon.reloadTime / reloadSpeedMultiplier);
        yield return new WaitForSeconds(equippedWeapon.reloadTime / reloadSpeedMultiplier);
        Reload();
        reloading = false;
        EventManager.Instance.RaiseOnPlayerReload();
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
