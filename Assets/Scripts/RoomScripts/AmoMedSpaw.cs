using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmoMedSpaw : MonoBehaviour
{
    //Skrypt umo¿liwiaj¹cy pojawie siê amunicji po zabiciu przeciwników
    [SerializeField] GameData gameData;
    private SpawnerTrigger sp;
    private Transform roomsParent;
    private Quaternion roomRot = Quaternion.Euler(0, 0, 0);
    public GameObject go;
    private int i = 0;
    private void spawn()
    {
        roomsParent = GameObject.FindGameObjectWithTag("Rooms").transform;
        Instantiate(gameData.GetRandomamomed(), transform.position, roomRot, roomsParent);
    }
    void Update()
    {
        if (go.GetComponent<SpawnerTrigger>().sp && gameData.enemMeter == 0)
        {
            if (i == 0)
            {
                int rand = Random.Range(1, 5);
                if (rand==2) {
                    spawn();
                    i++;
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
