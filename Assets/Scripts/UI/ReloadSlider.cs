using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadSlider : MonoBehaviour
{
    [SerializeField] private Image magImage;
    [SerializeField] private Image ringImage;
    private Slider slider;

    private void Start()
    {
        magImage.enabled = false;
        ringImage.enabled = false;
        slider = GetComponent<Slider>();
    }
    public void Play(float duration)
    {
        StartCoroutine(SliderCoroutine(duration));
    }
    private IEnumerator SliderCoroutine(float duration)
    {
        magImage.enabled = true;
        ringImage.enabled = true;
        slider.value = 0f;

        while(slider.value < 1)
        {
            slider.value = Mathf.Clamp(slider.value + Time.deltaTime / duration, 0, 1);
            yield return new WaitForEndOfFrame();
        }

        magImage.enabled = false;
        ringImage.enabled = false;
    }
}
