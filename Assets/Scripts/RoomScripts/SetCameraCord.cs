using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraCord : MonoBehaviour
{
    [SerializeField] GameData gameData;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameData.cx = transform.position.x;
            gameData.cy = transform.position.y;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().refresh();
        }
    }
}
