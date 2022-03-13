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
}
