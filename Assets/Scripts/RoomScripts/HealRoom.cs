using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRoom : MonoBehaviour
{
    private bool act = false;
    private bool used = false;
    private GameObject player;

    void Start()
    {
        StartCoroutine(heal(1.0f));
        player = GameObject.FindWithTag("Player");
        
    }
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && used==false)
        {
            act = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            act=false;
            used = true;
        }
    }
    IEnumerator heal(float time)
    {

        while (true)
        {
            if (act)
            {
                while (true)
                {
                    if(player.GetComponent<PlayerStatus>().currentHp<100)
                    player.GetComponent<PlayerStatus>().currentHp += 5;
                    yield return new WaitForSeconds(time);
                    if (!act)
                        break;
                }
                yield return new WaitForSeconds(0);
            }
            yield return new WaitForSeconds(0);
        }
    }
}
