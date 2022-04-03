using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Camera cam;

    public Vector2 facing;
    Vector2 movementDirectionVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = Camera.main;

        facing = new Vector2(0, -1);
        movementDirectionVector = new Vector2();
    }
    private void Update()
    {
        HandleInput();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleInput()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        movementDirectionVector = new Vector2(inputH, inputV).normalized;

        Vector2 mouseInGamePos = cam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 0));
        facing = new Vector2(mouseInGamePos.x - transform.position.x, mouseInGamePos.y - transform.position.y).normalized;
        if (facing.x >= 0)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }
    private void HandleMovement()
    {
        Vector2 displacementVector = movementDirectionVector * movementSpeed * Time.fixedDeltaTime;
        Vector2 newPos = (Vector2)transform.position + displacementVector;
        rb.MovePosition(newPos);

        if (movementDirectionVector.x != 0 || movementDirectionVector.y != 0)
        {
            animator.SetBool("isRunning", true);
            facing = movementDirectionVector;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        animator.SetFloat("Horizontal", facing.x);
        animator.SetFloat("Vertical", facing.y);
    }
}
