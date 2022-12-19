using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public bool hostile;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hostile && collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().Hit(damage);
            Destroy(gameObject);
        }
        else if (hostile && collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().Hit(damage);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("ExploBarel"))
        {
            collision.gameObject.SetActive(false);
            collision.gameObject.GetComponent<ExploBarel>().setac();
            Destroy(gameObject);
        }
    }
}
