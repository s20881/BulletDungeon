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
    public bool boss = false;
    public Light light1;
    public GameObject panel;
    
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
            gameData.PortalPenl = true;
            Time.timeScale = 0f;
        }
    }
    
}
