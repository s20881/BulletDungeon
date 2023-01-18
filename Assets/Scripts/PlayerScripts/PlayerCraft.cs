using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCraft : MonoBehaviour
{
    private int Upgrade = 0;
    public static int p = 0;

    public GameObject Panel;
    public TextMeshProUGUI scrapAmount;
    public TextMeshProUGUI gelAmount;
    public TextMeshProUGUI gunpowderAmount;
    public TextMeshProUGUI grenadesAmount;
    public TextMeshProUGUI mediGelAmount;

    public TextMeshProUGUI scrapInventory;
    public TextMeshProUGUI gelInventory;
    public TextMeshProUGUI gunpowderInventory;
    public TextMeshProUGUI grenadesInventory;
    public TextMeshProUGUI mediGelInventory;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI health;
    float arm;
    float hp;

    public GameObject PauzaMenu;
    public void OpenPanel()
    {
        arm = 1 - GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().damageReceivedMultiplier;
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().initialHealth;
        if (Panel != null)
        {
            PauzaMenu.SetActive(false);
            Panel.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
    public void ClosePanel()
    {
        if (Panel != null)
        {
            
            Panel.SetActive(false);
            Time.timeScale = 1;
        }
    }



    // Update is called once per frame
    void Update()
    {
        HandlePanels();
        scrapAmount.SetText(PlayerItems.scrap.ToString());
        gelAmount.SetText(PlayerItems.gel.ToString());
        gunpowderAmount.SetText(PlayerItems.gunpowder.ToString());
        grenadesAmount.SetText(PlayerCombat.totalGrenades.ToString() + "/3");
        mediGelAmount.SetText(PlayerItems.MediGel.ToString() + "/3");

        scrapInventory.SetText(PlayerItems.scrap.ToString());
        gelInventory.SetText(PlayerItems.gel.ToString());
        gunpowderInventory.SetText(PlayerItems.gunpowder.ToString());
        grenadesInventory.SetText(PlayerCombat.totalGrenades.ToString() + "/3");
        mediGelInventory.SetText(PlayerItems.MediGel.ToString() + "/3");
        armor.SetText(arm.ToString());
        health.SetText(hp.ToString());
        if (Input.GetKeyDown("e"))
        {
            switch (Upgrade)
            {
                case 1:
                    OpenPanel();
                    break;
                default:
                    break;
            }
        }
    }

    private void HandlePanels()
    {
        if (p == 0)
        {
            PauzaMenu.SetActive(true);
            Panel.SetActive(false);
            p = 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HpBoost"))
        {
            Upgrade = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Upgrade = 0;
    }
}
