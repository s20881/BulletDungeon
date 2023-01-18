using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;

    private void Start()
    {
        GetComponent<AudioSource>().volume = gameData.EffectsVolume;
    }
}
