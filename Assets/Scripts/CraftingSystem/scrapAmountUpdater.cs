using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrapAmountUpdater : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private int scrap;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scrap = PlayerItems.scrap;
        txt.text = scrap.ToString();
    }
}
