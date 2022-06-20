using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] OpeningDirection openingDirection;
    [SerializeField] private bool fakeSpawn;

    private Transform roomsParent;
    private Quaternion roomRot = Quaternion.Euler(0, 0, 0);
    private bool spawned = false;

    public bool Spawned
    {
        get { return spawned; }
        set { spawned = value; if (value == true)
                MapController.AssignRoom(transform.position);

        }
    }
    private void Start()
    {
        roomsParent = GameObject.FindGameObjectWithTag("Rooms").transform;
        if (fakeSpawn)
        {
            Spawned = true;
            return;
        }
        if (!Spawned && !MapController.HasRoomAt(transform.position))
        {
            Spawned = true;
            spawn();
        }
    }
     
    private void spawn()
    {
        Instantiate(gameData.GetRandomRoom(openingDirection), transform.position, roomRot, roomsParent);

      
            gameData.spawnMeter++;
    }
    
}

public enum OpeningDirection
{
    NeedUpDoor,
    NeedLeftDoor,
    NeedDownDoor,
    NeedRightDoor
}