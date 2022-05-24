using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [HideInInspector] public float damage;
    private bool damageApplied = false;

    public void ApplyDamage()
    {
        if(!damageApplied)
        {
            // hit all
            damageApplied = true;
        }
    }
}
