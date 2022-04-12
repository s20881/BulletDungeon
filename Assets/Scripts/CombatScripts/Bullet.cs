using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public GameObject shooter;

    private BoxCollider2D bc;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shooter.CompareTag("Player") && collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStatus>().Hit(damage);
            Destroy(gameObject);
        }
        else if (shooter.CompareTag("Enemy") && collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().Hit(damage);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
