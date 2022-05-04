using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }

    public delegate void PlayerHit();
    public static event PlayerHit OnPlayerHit;

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public delegate void PlayerShoot();
    public static event PlayerShoot OnPlayerShoot;

    public delegate void PlayerReload();
    public static event PlayerReload OnPlayerReload;

    public delegate void PlayerSwitchWeapon();
    public static event PlayerSwitchWeapon OnPlayerSwitchWeapon;

    public delegate void DroneHit();
    public static event DroneHit OnDroneHit;

    public delegate void DroneDeath();
    public static event DroneDeath OnDroneDeath;

    public delegate void DroneShoot();
    public static event DroneShoot OnDroneShoot;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
    }

    public void RaiseOnPlayerHit()
    {
        if (OnPlayerHit != null)
            OnPlayerHit();
    }
    public void RaiseOnPlayerDeath()
    {
        if (OnPlayerDeath != null)
            OnPlayerDeath();
    }
    public void RaiseOnPlayerShoot()
    {
        if (OnPlayerShoot != null)
            OnPlayerShoot();
    }
    public void RaiseOnPlayerReload()
    {
        if (OnPlayerReload != null)
            OnPlayerReload();
    }
    public void RaiseOnPlayerSwitchWeapon()
    {
        if (OnPlayerSwitchWeapon != null)
            OnPlayerSwitchWeapon();
    }
    public void RaiseOnDroneHit()
    {
        if (OnDroneHit != null)
            OnDroneHit();
    }
    public void RaiseOnDroneDeath()
    {
        if (OnDroneDeath != null)
            OnDroneDeath();
    }
    public void RaiseOnDroneShoot()
    {
        if (OnDroneShoot != null)
            OnDroneShoot();
    }
}
