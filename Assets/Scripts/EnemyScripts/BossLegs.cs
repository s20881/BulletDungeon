using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLegs : MonoBehaviour
{
    private SpriteRenderer sr;
    private SpriteRenderer bossRenderer;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bossRenderer = transform.parent.GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        EventManager.OnBossDeath += OnDeath;
    }
    private void OnDisable()
    {
        EventManager.OnBossDeath -= OnDeath;
    }
    private void FixedUpdate()
    {
        sr.flipX = bossRenderer.flipX;
    }

    private void OnDeath()
    {
        gameObject.SetActive(false);
    }
}
