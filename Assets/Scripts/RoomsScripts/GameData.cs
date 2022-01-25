using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameData", menuName ="Data/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private GameObject[] upRooms;
    [SerializeField] private GameObject[] downRooms;
    [SerializeField] private GameObject[] leftRooms;
    [SerializeField] private GameObject[] rightRooms;
    [SerializeField] private GameObject[] covers;
    [SerializeField] private GameObject[] enemies;
    public int spawnMeter ;
    public int enemMeter;

    public GameObject GetRandomRoom(OpeningDirection direction)
    {
        
        if (spawnMeter >= 7)
        {
            switch (direction)
            {
                case OpeningDirection.NeedUpDoor:
                    return upRooms[0];
                case OpeningDirection.NeedDownDoor:
                    return downRooms[0];
                case OpeningDirection.NeedLeftDoor:
                    return leftRooms[0];
                case OpeningDirection.NeedRightDoor:
                    return rightRooms[0];
                default: return null;
            }
        }
        else
        {
            switch (direction)
            {
                case OpeningDirection.NeedUpDoor:
                    return upRooms[Random.Range(1, upRooms.Length)];
                case OpeningDirection.NeedDownDoor:
                    return downRooms[Random.Range(1, downRooms.Length)];
                case OpeningDirection.NeedLeftDoor:
                    return leftRooms[Random.Range(1, leftRooms.Length)];
                case OpeningDirection.NeedRightDoor:
                    return rightRooms[Random.Range(1, rightRooms.Length)];
                default: return null;
            }
        }
    }
    public GameObject GetRandomCover()
    {
        return covers[Random.Range(0, covers.Length)];
    }
    public GameObject GetRandomEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
        
    }
}
 