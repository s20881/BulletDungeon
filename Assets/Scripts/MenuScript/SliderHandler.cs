using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    public Slider slider;
    public Slider slider1;
    [SerializeField] GameData gameData;
    void Start()
    {
        slider.onValueChanged.AddListener(delegate
        {
            ddVChange();
        });
        slider1.onValueChanged.AddListener(delegate
        {
            ddVChange1();
        });
    }
    public void ddVChange()
    {
        gameData.VolumeVal = slider.value;
    }
    public void ddVChange1()
    {
        gameData.EffectsVolume = slider1.value;
    }
    public void Update()
    {
        slider.value = gameData.VolumeVal;
        slider1.value = gameData.EffectsVolume;
    }
}
