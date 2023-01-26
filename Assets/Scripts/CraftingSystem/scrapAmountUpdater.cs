using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrapAmountUpdater : MonoBehaviour
{
    [SerializeField] PlayerItems items;
    private TextMeshProUGUI txt;
    private int scrap;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scrap = items.scrap;
        txt.text = scrap.ToString();
    }
}
