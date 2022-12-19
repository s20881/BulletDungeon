using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRoom : MonoBehaviour
{
    //skrypt fontanny lecz¹cej
    private bool act = false;
    private bool used = false;
    private GameObject player;
    public ParticleSystem ps;
    public GameObject localscale;
    private Vector3 scaleChange;
    private int cont; //licznik ilosci leczenia
    void Start()
    {
        StartCoroutine(heal(1.0f));
        player = GameObject.FindWithTag("Player");
        ps.Stop();
        scaleChange=new Vector3(-0.2f, 0.0f, 0.0f);
        cont = 0;
    }
    void Update()
    {
       if(cont == 10)
        {
            used = true;
            ps.Stop();
            act = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && used==false)
        {
            act = true;
            ps.Play();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            act=false;
            ps.Stop();
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
                    if (player.GetComponent<Health>().CurrentHealth < 90 && cont <10)
                    {
                        player.GetComponent<Health>().Heal(10);
                        localscale.transform.localScale += scaleChange;
                        cont++;
                    }
                    
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
