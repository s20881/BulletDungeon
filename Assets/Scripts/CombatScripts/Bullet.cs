using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public bool hostile;

    private BoxCollider2D bc;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hostile && collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStatus>().Hit(damage);
            Destroy(gameObject);
        }
        else if (hostile && collision.CompareTag("Player"))
        {
            if(collision.GetComponent<PlayerStatus>()!=null)
            collision.GetComponent<PlayerStatus>().Hit(damage);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
