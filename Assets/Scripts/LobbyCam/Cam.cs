using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;

    public float offsetSmooth = 6;
    private Vector3 playerPosition;
    void FixedUpdate()
    {
        playerPosition = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmooth * Time.deltaTime);
    }
}
