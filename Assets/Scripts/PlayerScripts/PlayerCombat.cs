using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float fireRateMultiplier = 1f;
    public float damageMultiplier = 1f;
    public float bulletSpeedMultiplier = 1f;
    public Weapon weapon;

    private IEnumerator shootingCoroutine;

    private void Start()
    {
        shootingCoroutine = Shooting();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(shootingCoroutine);
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(shootingCoroutine);
        }
    }

    public IEnumerator Shooting()
    {
        while (true)
        {
            weapon.Shoot(transform, damageMultiplier, bulletSpeedMultiplier);
            yield return new WaitForSeconds(1 / (weapon.fireRate * fireRateMultiplier));
        }
    }
}
