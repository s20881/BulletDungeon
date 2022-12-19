using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameData", menuName ="Data/GameData")]
public class GameData : ScriptableObject
{
    //Kontener zawierający objekty
    [SerializeField] private GameObject[] upRooms;
    [SerializeField] private GameObject[] downRooms;
    [SerializeField] private GameObject[] leftRooms;
    [SerializeField] private GameObject[] rightRooms;
    [SerializeField] private GameObject[] covers;
    [SerializeField] private EnemyType[] enemies;
    [SerializeField] private GameObject[] bossRooms;
    [SerializeField] private EnemyType[] bosses;
    [SerializeField] private GameObject[] amomed;
    //Ogólne zmienne
    //Poziom trudności
    public float level=1;
    public float levelenem = 1;
    //Liczniki 
    public int special = 0;
    public int spawnMeter ;
    public int enemMeter;
    //parametry
    public float cx;
    public float cy;
    public bool isbossroom = false;
    public int bossMeter=0;
    public bool isDead = false;
    public float VolumeVal;
    public bool PortalPenl = false;
    //eventt when die player zerowanie bossmeter i isboss na flase
    public GameObject GetRandomRoom(OpeningDirection direction)
    {
        if (spawnMeter == 0)
        {
            special = 0;
        }
        if (spawnMeter >= 0)//uzupełnianie zamkniętymi pomieszczeniami 
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
            int rand = Random.Range(1, 6);
            if (rand == 2 && special<2)//szansa na pojawienie sie specjanych pomieszczeń
            {
                
                special++;
                switch (direction)
                {
                    case OpeningDirection.NeedUpDoor:
                        return upRooms[Random.Range(4,5)];
                    case OpeningDirection.NeedDownDoor:
                        return downRooms[Random.Range(4,5)];
                    case OpeningDirection.NeedLeftDoor:
                        return leftRooms[5];
                    case OpeningDirection.NeedRightDoor:
                        return rightRooms[4];
                    default: return null;
                }
              
            }
            else
            {
                switch (direction)//respienie normalnych pokoi
                {
                    case OpeningDirection.NeedUpDoor:
                        return upRooms[Random.Range(1, upRooms.Length-2)];
                    case OpeningDirection.NeedDownDoor:
                        return downRooms[Random.Range(1, downRooms.Length-2)];
                    case OpeningDirection.NeedLeftDoor:
                        return leftRooms[Random.Range(1, leftRooms.Length-2)];
                    case OpeningDirection.NeedRightDoor:
                        return rightRooms[Random.Range(1, rightRooms.Length-2)];
                    default: return null;
                }
            }
        }
    }
    //metody zwracające odpowiednie objekty
    public GameObject GetRandomCover()
    {
        return covers[Random.Range(0, covers.Length)];
    }
    public EnemyType GetRandomEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
        
    }
    public GameObject GetRandomBossRoom()
    {
        return bossRooms[Random.Range(0, bossRooms.Length)];

    }
    public EnemyType GetRandomBoss()
    {
        return bosses[Random.Range(0, bosses.Length)];

    }
    public GameObject GetRandomamomed()
    {
        return amomed[Random.Range(0, amomed.Length)];

    }
    
}
 