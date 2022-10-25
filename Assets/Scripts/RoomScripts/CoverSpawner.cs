using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverSpawner : MonoBehaviour
{
    //Respienie osłon w pokojach
    [SerializeField] GameData gameData;
    private Transform roomsParent;
    private Quaternion roomRot = Quaternion.Euler(0, 0, 0);
    private void Start()
    {
        spawn();
    }
    private void spawn()
    {
        roomsParent = GameObject.FindGameObjectWithTag("Rooms").transform;
        Instantiate(gameData.GetRandomCover(), transform.position, roomRot, roomsParent);
    }
}
