using TMPro;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    

    public float scrap = 3;

    public int maxBactas = 2;

    public float bactas = 0;

    public TextMeshProUGUI textScrap;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textBacta;

    public bool canCraft = false;
    public bool canUpgradeHealth = false;


    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            if (canCraft == true)
                craft_Bacta();
            else if (canUpgradeHealth == true)
                upgrade_Health();
        }

        if (Input.GetKeyDown("h"))
        {
            if (bactas >= 1)
            {
                
                GameObject player = GameObject.Find("Player");
                PlayerMovement pl = player.GetComponent<PlayerMovement>();
                if (pl.health == pl.maxHealth)
                {
                    //do nothing
                }
                else if (pl.health < pl.maxHealth - 33)
                {
                    pl.health += 33;
                    bactas -= 1;
                }
                else
                {
                    bactas -= 1;
                    pl.health = pl.maxHealth;
                }
                textHealth.text = pl.health.ToString();
                textBacta.text = "Bacta: " + bactas.ToString();
            }
            else
            {
                Debug.Log("Nie masz miksturek");
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CraftBacta")
        {
            canCraft = true;
        }
        if (collision.transform.tag == "UpgradeHealth")
        {
            canUpgradeHealth = true;
        }
        if (collision.transform.tag == "Scrap")
        {
            Destroy(collision.gameObject);
            scrap += 1;
            textScrap.text = "Scrap: " + scrap.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "CraftBacta")
        {
            canCraft = false;
        }
        if (collision.tag == "UpgradeHealth")
        {
            canCraft = false;
        }
    }
    private void craft_Bacta()
    {
        if (scrap >= 3 && bactas < maxBactas)
        {
            bactas += 1;
            scrap -= 3;
            Debug.Log("Stworzyłeś Pojemnik Bacta. Masz ich: " + bactas);
            textScrap.text = "Scrap: " + scrap.ToString();
            textBacta.text = "Bacta: " + bactas.ToString();
        }
    }
    private void upgrade_Health()
    {
        if(scrap > 1)
        {
            scrap -= 1;
            GameObject player = GameObject.Find("Player");
            PlayerMovement pl = player.GetComponent<PlayerMovement>();
            pl.maxHealth += 5;
            textScrap.text = "Scrap: " + scrap.ToString();
        }
    }
}
