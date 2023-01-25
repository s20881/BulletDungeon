using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mediGelAmountUpdater : MonoBehaviour
{
    [SerializeField] PlayerItems items;
    private TextMeshProUGUI txt;
    private int mediGel;
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        mediGel = items.MediGel;
        txt.text = mediGel.ToString();
    }
}
