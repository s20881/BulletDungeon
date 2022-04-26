using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;
    public Vector2 currentDestination;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(!currentDestination.Equals((Vector2) transform.position))
        {
            rb.MovePosition(Vector2.Lerp(transform.position, currentDestination, movementSpeed * Time.fixedDeltaTime));
        }
    }
}
