using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoHud : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    private PlayerCombat pc;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        Refresh();
    }
    private void OnEnable()
    {
        EventManager.OnPlayerShoot += Refresh;
        EventManager.OnPlayerReload += Refresh;
        EventManager.OnPlayerSwitchWeapon += Refresh;
        EventManager.OnPlayerAmmoPickup += Refresh;
    }
    private void OnDisable()
    {
        EventManager.OnPlayerShoot -= Refresh;
        EventManager.OnPlayerReload -= Refresh;
        EventManager.OnPlayerSwitchWeapon -= Refresh;
        EventManager.OnPlayerAmmoPickup -= Refresh;
    }
    private void Refresh()
    {
        tmp.text = pc.EquippedWeaponTotalAmmo + "/" + pc.mag;
    }
}
