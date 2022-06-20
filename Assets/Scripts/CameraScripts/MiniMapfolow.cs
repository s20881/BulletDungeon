using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapfolow : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    void Start()
    {
        objectToFollow=GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
    }
}
