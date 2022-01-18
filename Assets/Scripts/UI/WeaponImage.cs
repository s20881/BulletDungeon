using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponImage : MonoBehaviour
{
    private PlayerCombat player;
    private Image image;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        image = GetComponent<Image>();
    }
    private void Update()
    {
        image.sprite = player.weapon.sprite;
    }
}
