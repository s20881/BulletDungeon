using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WweaponSpawn : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    private Quaternion roomRot = Quaternion.Euler(0, 0, 0);

    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
   public void Spawn()
    {
        int rand = Random.Range(0,1);
        if (rand == 0)
        {
            Instantiate(gameData.RandomWeapon(), transform.position, roomRot);
        }
        else
        {
            Instantiate(gameData.GetRandomamomed(), transform.position, roomRot);
        }
        
    }
}
