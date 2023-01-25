using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public GameObject Panel;
    public PlayerItems items;
    [SerializeField] private SaveScript save;

    public void healthUpgradeButton()
    {
        if (items.scrap >= 20 && items.gel >= 75)
        {
            items.scrap -= 20;
            items.gel -= 75;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().upgradeHealth();
            save.saveData();
        }
    }
    public void PotionCraftButton()
    {
        if (items.MediGel < 3)
        {

            if (items.gel >= 10)
            {
                items.gel -= 10;
                items.MediGel += 1;
                save.saveData();
            }
        }
    }
    public void armorUpgradeButton()
    {
        if((items.gel >= 50) && (items.scrap >= 150))
        {
            items.gel -= 50;
            items.scrap -= 150;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().upgradeArmor();
            save.saveData();
        }
    }

    public void grenadeCraftButton()
    {
        if ((items.gunpowder >= 15) && (items.scrap >= 15) && items.Grenades < 3)
        {
            items.gunpowder -= 15;
            items.scrap -= 15;
            items.Grenades += 1;
            save.saveData();
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
