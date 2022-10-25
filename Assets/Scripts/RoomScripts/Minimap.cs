using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Minimap : MonoBehaviour
{
    public GameObject minc;
    public GameObject fulc;
    
    private bool mini;
    private bool full;

    void Start()
    {
        minc.SetActive(false);
        fulc.SetActive(false);
        mini = false;
        full = false;
    }
//zmiana wyswietlania minimapy
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!mini)
            {
                minc.SetActive(true) ;
                mini = true;
                full = true;
            }
            else {
                if (full)
                {
                    fulc.SetActive(true);
                    minc.SetActive(false);
                    full = false;
                    
                }
                else
                {
                    if (mini)
                    {
                        fulc.SetActive(false);
                        minc.SetActive(false);
                        mini = false;
                        full = false;
                        
                    }
                }
                
            }
            

        }
    }
}
