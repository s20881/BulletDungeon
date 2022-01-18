using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    private BoxCollider2D bc;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.parent.CompareTag("Player") && collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (transform.parent.CompareTag("Enemy") && collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().PlayerHit(damage);
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
