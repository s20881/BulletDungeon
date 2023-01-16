using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon;
    private int mag;
    public float maxDistance = 1f;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private GameObject player;

    private void Start()
    {
        mag = weapon.magSize;
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (player != null) 
        if(DistanceToPlayer() < maxDistance && Input.GetButtonDown("Switch Weapon") && !player.GetComponent<PlayerCombat>().reloading)
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        Weapon previousPlayerWeapon = player.GetComponent<PlayerCombat>().equippedWeapon;
        int playerMag = player.GetComponent<PlayerCombat>().mag;
        player.GetComponent<PlayerCombat>().mag = mag;
        mag = playerMag;
        player.GetComponent<PlayerCombat>().equippedWeapon = weapon;
        weapon = previousPlayerWeapon;
        spriteRenderer.sprite = weapon.sprite;
        EventManager.Instance.RaiseOnPlayerSwitchWeapon();
        audioSource.Play();
    }
    public float DistanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
