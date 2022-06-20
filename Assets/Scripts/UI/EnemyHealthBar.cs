using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyStatus enemy;
    public float distanceAboveEnemy = 1f;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        if (enemy != null)
        {
            transform.position = enemy.transform.position + new Vector3(0, distanceAboveEnemy, 0);
            RefreshBar();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    private void RefreshBar()
    {
        slider.value = enemy.CurrentHealth / enemy.MaxHealth;
    }
}
