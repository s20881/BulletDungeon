using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespEn : MonoBehaviour
{
    [SerializeField] GameData gameData;
    private Quaternion roomRot = Quaternion.Euler(0, 0, 0);
    public GameObject go;
    private int i = 0;
    private SpriteRenderer spawner;
    private bool bol = false;
    private bool chek=false;
    public Transform ve3;
    public Vector2 ve2;
    private void Start()
    {
        spawner = GetComponent<SpriteRenderer>();
        spawner.enabled = false;
        StartCoroutine(ExecuteAfterTime(2.0f));
        StartCoroutine(spawntime(8.0f));
       
    }

    private void spawn()
    {
        Instantiate(gameData.GetRandomEnemy(), ve3.position, roomRot);
        gameData.enemMeter++;
    }
    private void Update()
    {
        if (go.GetComponent<SpawnerTrigger>().sp)
        {
            if (go.GetComponent<SpawnerTrigger>().wv)
            {
                chek = true;
            }
            else
            {
                if (i == 0)
                {
                     bol = true;
               
                    i++;
                }
            }
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {

        while (true)
        {
            if (bol)
            {
                spawner.enabled = true;
                gameData.enemMeter++;
                yield return new WaitForSeconds(time);
                gameData.enemMeter--;
                spawner.enabled = false;
                spawn();
                break;
            }
            yield return new WaitForSeconds(0);
        }
    }
    IEnumerator spawntime(float time)
    {
        int i = 0;
        while (true)
        {
            if (chek)
            {
                while (i < 3)
                {
                    spawn();
                    yield return new WaitForSeconds(time);
                    i++;
                   
                }
                break;
            }
            yield return new WaitForSeconds(0);
        }
    }
}
