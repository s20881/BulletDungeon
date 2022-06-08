using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedWeapon : MonoBehaviour
{
    private ParticleSystem flash;
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private SpriteRenderer spriteRenderer;
    public float distanceFromPlayer = 1f;
    private float originalDistanceFromPlayer;
    public Vector3 MuzzlePos
    {
        get
        {
            if(playerMovement.facing.x >= 0)
            {
                return playerCombat.equippedWeapon.muzzlePos;
            }
            else
            {
                return playerCombat.equippedWeapon.muzzlePos * new Vector3(1, -1, 1);
            }
        }
    }

    private void OnEnable()
    {
        EventManager.OnPlayerShoot += ShootEffect;
        EventManager.OnPlayerSwitchWeapon += RefreshSprite;
    }
    private void OnDisable()
    {
        EventManager.OnPlayerShoot -= ShootEffect;
        EventManager.OnPlayerSwitchWeapon -= RefreshSprite;
    }
    private void Start()
    {
        originalDistanceFromPlayer = distanceFromPlayer;
        flash = GetComponentInChildren<ParticleSystem>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerCombat = GetComponentInParent<PlayerCombat>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flash.transform.localPosition = playerCombat.equippedWeapon.muzzlePos;
        RefreshSprite();
    }
    private void Update()
    {
        transform.localPosition = playerMovement.facing * distanceFromPlayer;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, playerMovement.facing);
        if (playerMovement.facing.x >= 0)
        {
            spriteRenderer.flipY = false;
            flash.transform.localPosition = MuzzlePos;
        }
        else
        {
            spriteRenderer.flipY = true;
            flash.transform.localPosition = MuzzlePos;
        }
    }

    private void ShootEffect()
    {
        StartCoroutine(Recoil());
        flash.Play();
    }
    private void RefreshSprite()
    {
        spriteRenderer.sprite = playerCombat.equippedWeapon.sprite;
    }
    private IEnumerator Recoil()
    {
        float a = originalDistanceFromPlayer;
        float b = originalDistanceFromPlayer - playerCombat.equippedWeapon.recoilForce;
        float t = 0f;
        while (t < 1)
        {
            t += playerCombat.equippedWeapon.recoilSpeed * Time.deltaTime;
            distanceFromPlayer = Mathf.Lerp(a, b, t);
            yield return new WaitForEndOfFrame();
        }
        t = 0f;
        while (t < 1)
        {
            t += playerCombat.equippedWeapon.recoilSpeed * Time.deltaTime;
            distanceFromPlayer = Mathf.Lerp(b, a, t);
            yield return new WaitForEndOfFrame();
        }
    }
}
