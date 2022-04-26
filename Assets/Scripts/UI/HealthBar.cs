using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerStatus player;
    private Slider slider;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        RefreshBar();
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    private void RefreshBar()
    {
        slider.value = player.currentHp / player.maxHp;
    }
}
