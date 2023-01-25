using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemController : MonoBehaviour
{
    [SerializeField] public PlayerItems items;
    [SerializeField] private SaveScript save;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Scrap"))
        {
            Destroy(collision.gameObject);
            items.scrap+=50;
            save.saveData();
        }
        if (collision.CompareTag("Gel"))
        {
            Destroy(collision.gameObject);
            items.gel+=50;
            save.saveData();
        }
        if (collision.CompareTag("Gunpowder"))
        {
            Destroy(collision.gameObject);
            items.gunpowder++;
            save.saveData();
        }
        if (collision.CompareTag("MediGel"))
        {
            if (items.MediGel < 3)
            {
                Destroy(collision.gameObject);
                items.MediGel++;
                save.saveData();
            }
        }
        if (collision.CompareTag("Grenade"))
        {
            if (items.Grenades < 3)
            {
                Destroy(collision.gameObject);
                items.Grenades++;
                save.saveData();
            }
        }
    }
}
