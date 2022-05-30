using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    private float damage;

    private void Start()
    {
        damage = GetComponent<Bullet>().damage;
        GetComponent<Bullet>().damage = 0f;
    }
    private void OnDestroy()
    {
        GameObject explosion = Instantiate<GameObject>(explosionPrefab, transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().damage = damage;
        explosion.GetComponent<Explosion>().hostile = GetComponent<Bullet>().hostile;
    }
}
