using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;

    private void OnDestroy()
    {
        Instantiate<GameObject>(explosionPrefab, transform.position, Quaternion.identity);
    }
}
