using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoxs : MonoBehaviour
{
    [SerializeField] private GameObject gelPrefab;
    [SerializeField] private GameObject scrapPrefab;
    public bool isGel;
    public Transform ve3;
    public void setac()
    {
        //Instantiate(explosion, ve3.position, roomRot);// animacja niszczenia
        Destroy(gameObject);
        drop();
    }

    public void drop()
    {
        int a = Random.Range(3,6);

        for(int i=0; i<a; i++)
        {
            if (isGel)
            {
                Instantiate(gelPrefab, modV(ve3.position), Quaternion.identity);
            }
            else
            {
                Instantiate(scrapPrefab, modV(ve3.position), Quaternion.identity);
            }
        }      
    }
    public Vector3 modV(Vector3 v)
    {
        float a = Random.Range(0.1f, 0.5f);
        v.x = v.x + a;
        v.y = v.y + a;
        return v;
    }
}
