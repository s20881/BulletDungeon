using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public GameObject Panel;

    public void healthUpgradeButton()
    {
        if (PlayerItems.scrap >= 20)
        {
            PlayerItems.scrap -= 20;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().maxHp += 5;
            Debug.Log("Zwiêkszono maxHP o 5: " + GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().maxHp);
        }
    }
    public void PotionCraftButton()
    {
        if (PlayerItems.gel >= 5)
        {
            PlayerItems.gel -= 5;
            PlayerItems.MediGel += 1;
            Debug.Log("Stworzono MediGel");
        }
    }
    public void armorUpgradeButton()
    {
        if((PlayerItems.gel > 25) && (PlayerItems.scrap > 50))
        {
            //
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().damageReceivedMultiplier -= 0.05f;
            Debug.Log("Zwiekszono pancerz o 5%");
        }
    }



    public void closePanelButton()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
