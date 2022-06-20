using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private UnityEvent attackMethod;

    private void OnTriggerStay2D(Collider2D collision)
    {
        attackMethod.Invoke();
    }
}
