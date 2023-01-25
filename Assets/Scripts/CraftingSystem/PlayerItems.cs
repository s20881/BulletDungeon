using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public GameObject Inventory;
    public bool isOpen;

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
        if (Input.GetKeyDown(KeyCode.I)) {
            
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