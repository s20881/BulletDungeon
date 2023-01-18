using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed = 5f;
    Vector2 mousepos;
    Vector2 target;
    public GameObject explosion;
    private Camera cam;
    public GameObject[] enemies;
    public GameObject player;
    void Start()
    {
        mousepos = Input.mousePosition;
        cam = Camera.main;
        target = cam.ScreenToWorldPoint(mousepos);
    }

    // Update is called once per frame
    void Update()
    {
        if(speed > 0)
        {
            speed -= Random.Range(.01f, .02f);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }else if(speed < 0)
        {
            speed = 0;
            StartCoroutine(Explode(1));
        }
    }
    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var e in enemies)
        {
            var distance = Vector3.Distance(transform.position, e.transform.position);
            if (distance < 2.5)
            {
                e.GetComponent<Health>().Hit(200);
            }
        }
        player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(player.transform.position, transform.position) < 2.5)
        {
            player.GetComponent<Health>().Hit(10);
        }
    }
}
