using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;

    private void OnDestroy()
    {
        GameObject explosion = Instantiate<GameObject>(explosionPrefab, transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().damage = GetComponent<Bullet>().damage;
    }
}
