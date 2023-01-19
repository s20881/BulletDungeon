using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public GameObject Inventory;
    public bool isOpen;

    public static int gel = 15;
    public static int scrap = 11;
    public static int MediGel = 2;
    public static int gunpowder = 2;
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