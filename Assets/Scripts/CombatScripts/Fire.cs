using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Fire : MonoBehaviour
{
    public float damage = 10f;
    [SerializeField] private float duration = 5f;
    private PlayerStatus player;
    private Collider2D trigger;

    private void Start()
    {
        trigger = GetComponent<Collider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        StartCoroutine(Duration());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit");
            ApplyDamage();
        }
    }

    private void ApplyDamage()
    {
        player.Hit(damage * Time.deltaTime);
    }
    private IEnumerator Duration()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
