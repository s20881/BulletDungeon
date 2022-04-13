using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespEn : MonoBehaviour
{
    [SerializeField] GameData gameData;
    private Transform roomsParent;
    private Quaternion roomRot = Quaternion.Euler(0, 0, 0);
    public GameObject go;
    private SpawnerTrigger sp;
    private int i = 0;
    private int wave = 0;
    private void Start()
    {
        
    }

    private void spawn()
    {

        roomsParent = GameObject.FindGameObjectWithTag("Rooms").transform;

        Instantiate(gameData.GetRandomEnemy(), transform.position, roomRot, roomsParent);
        gameData.enemMeter++;
    }
    private void Update()
    {
        if (go.GetComponent<SpawnerTrigger>().sp)
        {
            if (go.GetComponent<SpawnerTrigger>().wv)
            {
                if (gameData.enemMeter <8 && wave < 3)
                {
                    wave++;
                    spawn();
                }
            }
            else
            {
                if (i == 0)
                {
                    spawn();
                    i++;
                }
            }
        }
    }
}
