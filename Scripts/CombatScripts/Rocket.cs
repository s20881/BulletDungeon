using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float damage;

    private BoxCollider2D bc;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Explosion");
        if(collision.transform.CompareTag("Obstacle") || collision.transform.CompareTag("Enemy"))
            Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        GameObject.Destroy(gameObject);
    }
}
