using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemUse : MonoBehaviour
{
    public float movementSpeed = 1f;

    public GameObject particles;
    private float getHP;
    private float getMaxHP;

    public Vector2 facing;
    private void Start()
    {
        particles.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            if (PlayerItems.MediGel > 1)
            { 
                getHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().CurrentHealth;
                getMaxHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().MaxHealth;
                if (getHP < getMaxHP - 33f)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Heal(33f);
                    PlayerItems.MediGel -= 1;
                }
                else if (getMaxHP - getHP < 33f && getMaxHP - getHP > 0f)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Heal(getMaxHP);
                    PlayerItems.MediGel -= 1;
                }
                particles.SetActive(true);
                Instantiate(particles, transform.position, Quaternion.identity);
                StartCoroutine(HealingCoroutine(2));
                Destroy(particles);
            }
        }
    }
    private IEnumerator HealingCoroutine(float duration)
    {
        particles.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        yield return new WaitForSeconds(duration);
        particles.SetActive(false);
    }
}

