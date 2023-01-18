using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public GameObject Panel;

    public void healthUpgradeButton()
    {
        if (PlayerItems.scrap >= 20 && PlayerItems.gel >= 75)
        {
            PlayerItems.scrap -= 20;
            PlayerItems.gel -= 75;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().upgradeHealth();
        }
    }
    public void PotionCraftButton()
    {
        if (PlayerItems.MediGel < 3)
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
        if((PlayerItems.gel >= 50) && (PlayerItems.scrap >= 150))
        {
            PlayerItems.gel -= 25;
            PlayerItems.scrap -= 50;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().upgradeArmor();
        }
    }

    public void grenadeCraftButton()
    {
        if ((PlayerItems.gunpowder >= 15) && (PlayerItems.scrap >= 15) && PlayerCombat.totalGrenades < 3)
        {
            PlayerItems.gunpowder -= 15;
            PlayerItems.scrap -= 15;
            PlayerCombat.totalGrenades += 1;
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
