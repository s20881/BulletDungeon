using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Health player;
    private Slider slider;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        RefreshBar();
    }

    private void RefreshBar()
    {
        slider.value = player.CurrentHealth / player.MaxHealth;
    }
}
