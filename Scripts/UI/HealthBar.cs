using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    private void Update()
    {
        if (playerStatus == null) playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        else
        gameObject.transform.localScale = new Vector3(playerStatus.currentHp / playerStatus.maxHp, playerStatus.transform.localScale.y, playerStatus.transform.localScale.z);
    }
}
