using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    public Vector2 currentDestination;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform player;

    private void Start()
    {
        currentDestination = transform.position;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        if (!ReachedDestination())
        {
            rb.MovePosition(Vector2.MoveTowards(transform.position, currentDestination, movementSpeed * Time.fixedDeltaTime));
        }
        UpdateFacing();
    }
    private void UpdateFacing()
    {
        if (player.position.x > transform.position.x)
            sr.flipX = false;
        else
            sr.flipX = true;
    }
    public bool ReachedDestination()
    {
        if (currentDestination == (Vector2)transform.position)
            return true;
        else
            return false;
    }
}
