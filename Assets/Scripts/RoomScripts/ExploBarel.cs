using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ExploBarel : MonoBehaviour
{
    public GameObject explosion;
    public Transform ve3;
    public GameObject[] enemies;
    public GameObject player;
    private Quaternion roomRot = Quaternion.Euler(0, 0, 0);

    public void setac()
    {
        Instantiate(explosion, ve3.position, roomRot);
        Destroy(gameObject);
        damageexplo();
    }

    public void damageexplo()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var e in enemies)
        {
            var distance = Vector3.Distance(transform.position, e.transform.position);
            if(distance < 2.5)
            {
                e.GetComponent<EnemyStatus>().Hit(200);
            }
        }
        player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(player.transform.position,transform.position)<2.5)
        {
            player.GetComponent<PlayerStatus>().Hit(10);
        }
    }

}
