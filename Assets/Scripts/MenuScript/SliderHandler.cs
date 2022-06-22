using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    public Slider slider;
    [SerializeField] GameData gameData;
    void Start()
    {
        slider.onValueChanged.AddListener(delegate
        {
            ddVChange();
        });
    }
    public void ddVChange()
    {
        gameData.VolumeVal = slider.value;
    }
}
