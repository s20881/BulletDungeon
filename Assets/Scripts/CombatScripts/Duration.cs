using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : MonoBehaviour
{
    [SerializeField] private float duration = 1f;

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
