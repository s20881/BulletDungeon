using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    private GameObject player;

    private void OnEnable()
    {
        EventManager.OnDroneDeath += DecreaseEnemyMeter;
        EventManager.OnRobotDeath += DecreaseEnemyMeter;
        EventManager.OnPlayerDeath += GameDataSetDead;
        EventManager.OnPlayerSpawn += SetPlayerDamageReceiverMultiplier;
    }
    private void OnDisable()
    {
        EventManager.OnDroneDeath -= DecreaseEnemyMeter;
        EventManager.OnRobotDeath -= DecreaseEnemyMeter;
        EventManager.OnPlayerDeath -= GameDataSetDead;
        EventManager.OnPlayerSpawn -= SetPlayerDamageReceiverMultiplier;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void DecreaseEnemyMeter()
    {
        gameData.enemMeter--;
    }
    private void GameDataSetDead()
    {
        gameData.isDead = true;
    }
    private void SetPlayerDamageReceiverMultiplier()
    {
        player.GetComponent<Health>().damageReceivedMultiplier = gameData.level;
    }
}
