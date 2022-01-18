using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;

    private Rigidbody2D rb;
    private Animator animator;

    public Vector2 facing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        facing = new Vector2(0, -1);
    }
    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Vector2 directionVector = new Vector2(inputH, inputV).normalized;
        Vector2 displacementVector = directionVector * movementSpeed * Time.deltaTime;
        Vector2 newPos = (Vector2)transform.position + displacementVector;
        rb.MovePosition(newPos);

        if (directionVector.x != 0 || directionVector.y != 0)
        {
            animator.SetBool("isRunning", true);
            facing = directionVector;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        animator.SetFloat("Horizontal", facing.x);
        animator.SetFloat("Vertical", facing.y);
    }
}
