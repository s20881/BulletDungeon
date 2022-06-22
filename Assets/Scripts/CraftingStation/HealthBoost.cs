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
        }
    }
    public void PotionCraftButton()
    {
        if (PlayerItems.MediGel < 2)
        {

            if (PlayerItems.gel >= 10)
            {
                PlayerItems.gel -= 10;
                PlayerItems.MediGel += 1;
            }
        }
    }
    public void armorUpgradeButton()
    {
        if((PlayerItems.gel > 25) && (PlayerItems.scrap > 50))
        {
            PlayerItems.gel -= 25;
            PlayerItems.scrap -= 50;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().damageReceivedMultiplier -= 0.05f;
        }
    }


    public void closePanelButton()
    {
        if (Panel != null)
        {
            PlayerCraft.p = 0;
            Panel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
