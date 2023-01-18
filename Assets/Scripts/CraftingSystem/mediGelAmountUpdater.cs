using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mediGelAmountUpdater : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private int mediGel;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        mediGel = PlayerItems.MediGel;
        txt.text = mediGel.ToString();
    }
}
