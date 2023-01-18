using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int mag;
    public int totalPistolAmmo = 21;
    public int totalRifleAmmo = 90;
    public int totalRocketAmmo = 5;
    public static int totalGrenades = 1;
    public GameObject grenade;

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
    [SerializeField] private GameObject sliderPrefab;
    private ReloadSlider slider;
    [SerializeField] private AudioClip reloadSound;

    private PlayerMovement playerMovement;
    private Animator animator;
    private EquippedWeapon inGameWeapon;
    private AudioSource audioSource;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        inGameWeapon = GetComponentInChildren<EquippedWeapon>();
        audioSource = GetComponent<AudioSource>();
        slider = Instantiate<GameObject>(sliderPrefab, GameObject.Find("WorldSpaceCanvas").transform).GetComponent<ReloadSlider>();
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
        if (Input.GetKeyDown(KeyCode.G) && totalGrenades>0)
        {
            Instantiate(grenade, transform.position, Quaternion.identity);
            totalGrenades--;
        }
    }

    private void Shoot()
    {
        Vector3 bulletPos = inGameWeapon.transform.TransformPoint(inGameWeapon.MuzzlePos);
        equippedWeapon.Shoot(gameObject, damageMultiplier, bulletSpeedMultiplier, bulletPos, playerMovement.facing);
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
        audioSource.PlayOneShot(reloadSound);
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
    public void AddAmmo(int ammo)
    {
        EquippedWeaponTotalAmmo += ammo;
        EventManager.Instance.RaiseOnPlayerAmmoPickup();
    }
}
