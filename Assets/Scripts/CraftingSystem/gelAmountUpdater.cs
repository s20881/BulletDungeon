using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gelAmountUpdater : MonoBehaviour
{
    [SerializeField] PlayerItems items;
    private TextMeshProUGUI txt;
    private int gel;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        gel = items.gel;
        txt.text = gel.ToString();
    }
}
