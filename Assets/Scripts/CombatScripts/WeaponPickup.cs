using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon;
    public float maxDistance = 1f;

    private SpriteRenderer spriteRenderer;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(DistanceToPlayer() < maxDistance && Input.GetButtonDown("Jump"))
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        Weapon previousPlayerWeapon = player.GetComponent<PlayerCombat>().weapon;
        player.GetComponent<PlayerCombat>().weapon = weapon;
        if(weapon.weaponName == "Pistol")
        {
            player.GetComponent<Animator>().SetTrigger("PistolEquipped");
        }
        else if(weapon.weaponName == "Assault Rifle")
        {
            player.GetComponent<Animator>().SetTrigger("AREquipped");
        }
        else if(weapon.weaponName == "Rocket Launcher")
        {
            player.GetComponent<Animator>().SetTrigger("RLEquipped");
        }
        weapon = previousPlayerWeapon;
        spriteRenderer.sprite = weapon.sprite;
    }
    public float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
