using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Scrap"))
        {
            Destroy(collision.gameObject);
            PlayerItems.scrap++;
        }
        if (collision.CompareTag("Gel"))
        {
            Destroy(collision.gameObject);
            PlayerItems.gel++;
        }
        if (collision.CompareTag("Gunpowder"))
        {
            Destroy(collision.gameObject);
            PlayerItems.gunpowder++;
        }
        if (collision.CompareTag("MediGel"))
        {
            if (PlayerItems.MediGel < 3)
            {
                Destroy(collision.gameObject);
                PlayerItems.MediGel++;
            }
        }
        if (collision.CompareTag("Grenade"))
        {
            if (PlayerCombat.totalGrenades < 3)
            {
                Destroy(collision.gameObject);
                PlayerCombat.totalGrenades++;
            }
        }
    }
}
