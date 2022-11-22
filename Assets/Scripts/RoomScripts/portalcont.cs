using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class portalcont : MonoBehaviour
{
    [SerializeField] GameData gameData;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxcollider;
    string title = "BulletDungeon";
    string message = "Czy chcesz przej�� dalej";
    string ok = "tak";
    string cancel = "nie";
    public bool boss = false;
    public Light light1;
    
    // Start is called before the first frame update
    void Start()
    {
        
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.boxcollider = GetComponent<BoxCollider2D>();
       
        boxcollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(light1 ?? false)
        if (gameData.spawnMeter < 0 && gameData.enemMeter==0)
        {    
            spriteRenderer.enabled = true;
            boxcollider.enabled = true;
            light1.enabled = true;
           
        }
        else
        {
            spriteRenderer.enabled = false;
            boxcollider.enabled = false;
            light1.enabled = false;
           
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bool st = EditorUtility.DisplayDialog(title,message,ok,cancel);
            if (st)
            {
                
                    if (!gameData.isbossroom)
                    {
                    
                    SceneManager.LoadScene("BossScene");
                        gameData.isbossroom = true;
                    }
                    else
                    {
                    if (gameData.bossMeter == 2)
                    {
                        SceneManager.LoadScene("EndScene");
                    }
                    else
                    {
                        SceneManager.LoadScene("RoomScene");
                        gameData.isbossroom = false;
                        gameData.level += 0.15f;
                        gameData.levelenem -= 0.15f;
                        gameData.bossMeter += 1;
                    }
                   
                    }
                
               
               
            }
        }
    }
}
