using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomInventory : MonoBehaviour
{
    public GameObject Inventory;
    public bool isOpen;
    public TextMeshProUGUI scrapInventory;
    public TextMeshProUGUI gelInventory;
    public TextMeshProUGUI gunpowderInventory;
    public TextMeshProUGUI grenadesInventory;
    public TextMeshProUGUI mediGelInventory;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI health;

    float arm;
    float hp;

    [SerializeField] PlayerItems items;

    [SerializeField] public int gel { get; set; }
    [SerializeField] public int scrap { get; set; }
    [SerializeField] public int MediGel { get; set; }
    [SerializeField] public int gunpowder { get; set; }
    [SerializeField] public int Grenades { get; set; }
    private void Start()
    {
        isOpen = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            arm = 1 - GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().damageReceivedMultiplier;
            hp = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().CurrentHealth;
            scrapInventory.SetText(items.scrap.ToString());
            gelInventory.SetText(items.gel.ToString());
            gunpowderInventory.SetText(items.gunpowder.ToString());
            grenadesInventory.SetText(items.Grenades.ToString() + "/3");
            mediGelInventory.SetText(items.MediGel.ToString() + "/3");
            armor.SetText(arm.ToString());
            health.SetText(hp.ToString());

            if (isOpen == false)
            {
                Inventory.SetActive(true);
                isOpen = true;
            }
            else
            {
                Inventory.SetActive(false);
                isOpen = false;
            }
        }
    }
}