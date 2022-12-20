using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mediGelAmountUpdater : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private int mediGel;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        mediGel = PlayerItems.MediGel;
        txt.text = mediGel.ToString();
    }
}
