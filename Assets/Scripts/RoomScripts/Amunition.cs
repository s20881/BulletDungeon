using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Amunition : MonoBehaviour
{

    void Start()
    {
    }
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().AddAmmo(10);
            Destroy(this.gameObject);
        }
    }
}
