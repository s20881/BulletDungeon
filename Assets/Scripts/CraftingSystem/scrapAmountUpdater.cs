using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scrapAmountUpdater : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private int scrap;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scrap = PlayerItems.scrap;
        txt.text = scrap.ToString();
    }
}
