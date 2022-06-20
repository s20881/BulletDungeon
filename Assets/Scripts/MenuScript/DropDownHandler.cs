using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropDownHandler : MonoBehaviour
{
    public Dropdown dd;
    public GameObject player;
    public float mult;
    [SerializeField] GameData gameData;
    void Start()
    {
        dd.onValueChanged.AddListener(delegate
       {
           ddVChange(dd);
       });
    }

    public void ddVChange(Dropdown sender)
    {
       
        if (sender.value == 0)
        {
            gameData.level = 1f;
            gameData.levelenem = 1f;
        }

        if (sender.value == 1)
        {
            gameData.level = 0.7f;
            gameData.levelenem = 1.2f;
        }
            
        if (sender.value == 2)
        {
            gameData.level = 1.2f;
            gameData.levelenem = 0.8f;
        }
            
        
    }
}
