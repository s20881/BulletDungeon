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

    public GameObject craft;
    float arm;
    float hp;

    [SerializeField] PlayerItems items;
    public GameObject PauzaMenu;
    public void OpenPanel()
    {
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



    void Update()
    {
        arm = (GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().armor)*100f;
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().initialHealth;

        HandlePanels();
        scrapAmount.SetText(items.scrap.ToString());
        gelAmount.SetText(items.gel.ToString());
        gunpowderAmount.SetText(items.gunpowder.ToString());
        grenadesAmount.SetText(items.Grenades.ToString() + "/3");
        mediGelAmount.SetText(items.MediGel.ToString() + "/3");

        scrapInventory.SetText(items.scrap.ToString());
        gelInventory.SetText(items.gel.ToString());
        gunpowderInventory.SetText(items.gunpowder.ToString());
        grenadesInventory.SetText(items.Grenades.ToString() + "/3");
        mediGelInventory.SetText(items.MediGel.ToString() + "/3");
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
            craft.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Upgrade = 0;
        craft.SetActive(false);
    }
}
