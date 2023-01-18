using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gelAmountUpdater : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private int gel;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        gel = PlayerItems.gel;
        txt.text = gel.ToString();
    }
}
