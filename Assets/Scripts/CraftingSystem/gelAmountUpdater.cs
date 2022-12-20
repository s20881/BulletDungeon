using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gelAmountUpdater : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private int gel;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gel = PlayerItems.gel;
        txt.text = gel.ToString();
    }
}
