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
            Debug.Log("Z³om: "+PlayerItems.scrap);
        }
        if (collision.CompareTag("Gel"))
        {
            Destroy(collision.gameObject);
            PlayerItems.scrap++;
            Debug.Log("Z³om: " + PlayerItems.scrap);
        }
    }
}
