using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }

    public delegate void PlayerDeath();
    public static event PlayerDeath OnPlayerDeath;

    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    public delegate void PlayerShoot();
    public static event PlayerShoot OnPlayerShoot;

    public delegate void PlayerReload();
    public static event PlayerReload OnPlayerReload;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
    }

    public void RaiseOnPlayerDeath()
    {
        if (OnPlayerDeath != null)
            OnPlayerDeath();
    }
    public void RaiseOnEnemyKilled()
    {
        if (OnEnemyKilled != null)
            OnEnemyKilled();
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
}
