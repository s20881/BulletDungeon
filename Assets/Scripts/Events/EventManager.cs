using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }

    public delegate void PlayerSpawn();
    public static event PlayerSpawn OnPlayerSpawn;

    public delegate void PlayerHit();
    public static event PlayerHit OnPlayerHit;

    public delegate void PlayerHeal();
    public static event PlayerHeal OnPlayerHeal;

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public delegate void PlayerShoot();
    public static event PlayerShoot OnPlayerShoot;

    public delegate void PlayerReload();
    public static event PlayerReload OnPlayerReload;

    public delegate void PlayerSwitchWeapon();
    public static event PlayerSwitchWeapon OnPlayerSwitchWeapon;

    public delegate void PlayerAmmoPickup();
    public static event PlayerAmmoPickup OnPlayerAmmoPickup;

    public delegate void DroneHit();
    public static event DroneHit OnDroneHit;

    public delegate void DroneDeath();
    public static event DroneDeath OnDroneDeath;

    public delegate void DroneShoot();
    public static event DroneShoot OnDroneShoot;

    public delegate void RobotHit();
    public static event RobotHit OnRobotHit;

    public delegate void RobotDeath();
    public static event RobotDeath OnRobotDeath;

    public delegate void RobotAttack();
    public static event RobotAttack OnRobotAttack;

    public delegate void BossHit();
    public static event BossHit OnBossHit;

    public delegate void BossDeath();
    public static event BossDeath OnBossDeath;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
    }

    public void RaiseOnPlayerSpawn()
    {
        if(OnPlayerSpawn != null)
            OnPlayerSpawn();
    }
    public void RaiseOnPlayerHit()
    {
        if (OnPlayerHit != null)
            OnPlayerHit();
    }
    public void RaiseOnPlayerHeal()
    {
        if (OnPlayerHeal != null)
            OnPlayerHeal();
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
    public void RaiseOnPlayerAmmoPickup()
    {
        if (OnPlayerAmmoPickup != null)
            OnPlayerAmmoPickup();
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
    public void RaiseOnRobotHit()
    {
        if (OnRobotHit != null)
            OnRobotHit();
    }
    public void RaiseOnRobotDeath()
    {
        if (OnRobotDeath != null)
            OnRobotDeath();
    }
    public void RaiseOnRobotAttack()
    {
        if (OnRobotAttack != null)
            OnRobotAttack();
    }
    public void RaiseOnBossHit()
    {
        if (OnBossHit != null)
            OnBossHit();
    }
    public void RaiseOnBossDeath()
    {
        if (OnBossDeath != null)
            OnBossDeath();
    }
}
