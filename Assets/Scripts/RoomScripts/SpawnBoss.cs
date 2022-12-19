using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    //repienie boss�w
    [SerializeField] GameData gameData;
    private Transform roomsParent;
    private Quaternion roomRot = Quaternion.Euler(0, 0, 0);
    private void Start()
    {
        gameData.enemMeter = 0;
        spawn();
        gameData.enemMeter++;
    }

    private void spawn()
    {
        EnemySpawner.Instance.Spawn(gameData.GetRandomBoss(), transform.position);
    }
}
