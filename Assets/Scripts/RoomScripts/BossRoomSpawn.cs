using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomSpawn : MonoBehaviour
{
    //Respienie randomowego Bossrooma
    [SerializeField] GameData gameData;
    private Transform roomsParent;
    private Quaternion roomRot = Quaternion.Euler(0, 0, 0);
    private void Start()
    {
        spawn();
    }
    private void spawn()
    {
        Instantiate(gameData.GetRandomBossRoom(), transform.position, roomRot);
    }
}
