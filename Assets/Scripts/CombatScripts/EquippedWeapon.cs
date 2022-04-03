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
        flash = GetComponentInChildren<ParticleSystem>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        playerCombat = GetComponentInParent<PlayerCombat>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flash.gameObject.transform.localPosition = playerCombat.equippedWeapon.muzzlePos;
    }
    private void Update()
    {
        transform.localPosition = playerMovement.facing * distanceFromPlayer;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, playerMovement.facing);
        if (playerMovement.facing.x >= 0)
            spriteRenderer.flipY = false;
        else
            spriteRenderer.flipY = true;
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
        float a = distanceFromPlayer;
        float b = distanceFromPlayer - playerCombat.equippedWeapon.recoilForce;
        float t = 0f;
        while (t < 1)
        {
            distanceFromPlayer = Mathf.Lerp(a, b, t);
            t += playerCombat.equippedWeapon.recoilSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        t = 0f;
        while (t < 1)
        {
            distanceFromPlayer = Mathf.Lerp(b, a, t);
            t += playerCombat.equippedWeapon.recoilSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
