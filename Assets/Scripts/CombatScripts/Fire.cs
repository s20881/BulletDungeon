using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Fire : MonoBehaviour
{
    public float damage = 10f;
    private Health player;
    private Collider2D trigger;

    private void Start()
    {
        trigger = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ApplyDamage();
        }
    }

    private void ApplyDamage()
    {
        player.Hit(damage * Time.deltaTime);
    }
}
