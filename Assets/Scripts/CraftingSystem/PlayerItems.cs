using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public GameObject Inventory;
    public bool isOpen;

    public static int gel = 82;
    public static int scrap = 131;
    public static int MediGel = 1;
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