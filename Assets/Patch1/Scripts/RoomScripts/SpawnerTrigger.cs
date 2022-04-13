﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
   public bool sp;
    public bool wv;
    public bool firsttrig=true;
    public GameObject u;
    public GameObject d;
    public GameObject r;
    public GameObject l;
    public bool specialRoomtf;
    [SerializeField] GameData gameData;
    private  List<GameObject> entr;
    private  List<GameObject> doors;
    private void Start()
    {
        entr = new List<GameObject>();
        doors = new List<GameObject>();
        entr.Add(u);
        entr.Add(d);
        entr.Add(l);
        entr.Add(r);
        foreach (GameObject o in entr)
        {           
            if (!o.activeSelf)
            {
                doors.Add(o);         
            }
        }
        sp = false;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sp = true;
            if (firsttrig)
            {
                gameData.spawnMeter--;
                firsttrig = false;
            }
           
        }
    }
    private void Update()
    {
        if (specialRoomtf)
        {
            
        }
        else
        if (sp)
        {
            if (gameData.enemMeter == 0)
            {
                foreach (GameObject o in doors)
                {
                    o.SetActive(false);
                   
                }
            }
            else
            {
                foreach (GameObject o in doors)
                {
                    o.SetActive(true);
                }
            }
                      
        }
        
    }

}
