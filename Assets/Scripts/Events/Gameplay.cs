using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] GameData gameData;

    private void OnEnable()
    {
        EventManager.OnDroneDeath += DecreaseEnemyMeter;
    }
    private void OnDisable()
    {
        EventManager.OnDroneDeath -= DecreaseEnemyMeter;
    }

    private void DecreaseEnemyMeter()
    {
        gameData.enemMeter--;
    }
}
