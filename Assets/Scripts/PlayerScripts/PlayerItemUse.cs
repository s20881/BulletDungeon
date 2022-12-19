using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemUse : MonoBehaviour
{
    public float movementSpeed = 1f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Camera cam;
    private float getHP;
    private float getMaxHP;

    public Vector2 facing;
    Vector2 movementDirectionVector;

    private void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            if (PlayerItems.MediGel > 1)
            { 
                getHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().CurrentHealth;
                getMaxHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().MaxHealth;
                if (getHP < getMaxHP - 33)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Heal(33);
                    PlayerItems.MediGel -= 1;
                }
                else if (getMaxHP - getHP < 33 && getMaxHP - getHP > 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Heal(getMaxHP);
                    PlayerItems.MediGel -= 1;
                }
            }
        }
    }
}
