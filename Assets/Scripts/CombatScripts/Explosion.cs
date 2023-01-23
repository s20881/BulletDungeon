using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [HideInInspector] public float damage;
    [HideInInspector] public bool hostile;
    private bool damageApplied = false;

    private void Update()
    {
        if(!damageApplied && damage != 0f)
            ApplyDamage();
    }
    public void ApplyDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
        foreach(Collider2D hit in hits)
        {
            if(hit.CompareTag("Player") && hostile)
            {
                hit.GetComponent<Health>().Hit(damage);
            }
            else if(hit.CompareTag("Enemy") && !hostile)
            {
                hit.GetComponent<Health>().Hit(damage);
            }
            else if(hit.CompareTag("ExploBarel"))
            {
                hit.gameObject.SetActive(false);
                hit.GetComponent<ExploBarel>().setac();
            }
            else if(hit.CompareTag("GelBox") || hit.CompareTag("ScrapBox"))
            {
                hit.gameObject.SetActive(false);
                hit.GetComponent<DropBoxs>().setac();
            }
        }
        damageApplied = true;
    }
}
