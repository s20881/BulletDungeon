using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemUse : MonoBehaviour
{
    public float movementSpeed = 1f;

    public GameObject particles;
    private float getHP;
    private float getMaxHP;
    [SerializeField] PlayerItems items;
    [SerializeField] private SaveScript save;

    public Vector2 facing;
    private void Start()
    {
        particles.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            if (items.MediGel > 1)
            { 
                getHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().CurrentHealth;
                getMaxHP = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().MaxHealth;
                if (getHP < getMaxHP - 33f)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Heal(33f);
                    items.MediGel -= 1;
                }
                else if (getMaxHP - getHP < 33f && getMaxHP - getHP > 0f)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().Heal(getMaxHP);
                    items.MediGel -= 1;
                }
                particles.SetActive(true);
                Instantiate(particles, transform.position, Quaternion.identity);
                StartCoroutine(HealingCoroutine(2));
                particles.SetActive(false);
                save.saveData();
            }
        }
    }
    private IEnumerator HealingCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}

