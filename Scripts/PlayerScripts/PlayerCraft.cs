using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCraft : MonoBehaviour
{
    private int Upgrade = 0;
    private int p = 0;

    public GameObject Panel;

    public void OpenPanel()
    {
        if(Panel != null)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ClosePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
            Time.timeScale = 1;
        }
    }



    // Update is called once per frame
    void Update()
    {
        HandlePanels();
        if (Input.GetKeyDown("e"))
        {
            switch (Upgrade)
            {
                case 1:
                    OpenPanel();
                    break;
                default:
                    break;
            }
        }
    }

    private void HandlePanels()
    {
        if (p == 0)
        {
            Panel.SetActive(false);
            p = 1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HpBoost"));
        {
            Upgrade = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Upgrade = 0;
    }
}
