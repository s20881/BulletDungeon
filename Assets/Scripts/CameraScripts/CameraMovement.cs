using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    [SerializeField] GameData gameData;

    private void Update()
    {

        if (objectToFollow ?? false)
            if (gameData.isbossroom)
        {
            if (objectToFollow.transform.position.x >  - 4.1f && objectToFollow.transform.position.x <  4.1f && objectToFollow.transform.position.y >  - 6.6f && objectToFollow.transform.position.y < + 6.6f)
            {
                transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            }
            if (!(objectToFollow.transform.position.x > - 4.1f && objectToFollow.transform.position.x <  4.1f && objectToFollow.transform.position.y >  - 6.6f && objectToFollow.transform.position.y <   6.6f))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            if (!(objectToFollow.transform.position.x > - 4.1f && objectToFollow.transform.position.x <  4.1f) && objectToFollow.transform.position.y >  - 6.6f && objectToFollow.transform.position.y <   6.6f)
            {
                transform.position = new Vector3(transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            }
            if (objectToFollow.transform.position.x >  - 4.1f && objectToFollow.transform.position.x <  4.1f && !(objectToFollow.transform.position.y >  - 6.6f && objectToFollow.transform.position.y <   6.6f))
            {
                transform.position = new Vector3(objectToFollow.transform.position.x, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (objectToFollow.transform.position.x > gameData.cx - 1.1f && objectToFollow.transform.position.x < gameData.cx + 1.1f && objectToFollow.transform.position.y > gameData.cy - 5f && objectToFollow.transform.position.y < gameData.cy + 5f)
            {
                transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            }
            if (!(objectToFollow.transform.position.x > gameData.cx - 1.1f && objectToFollow.transform.position.x < gameData.cx + 1.1f && objectToFollow.transform.position.y > gameData.cy - 5f && objectToFollow.transform.position.y < gameData.cy + 5f))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            if (!(objectToFollow.transform.position.x > gameData.cx - 1.1f && objectToFollow.transform.position.x < gameData.cx + 1.1f) && objectToFollow.transform.position.y > gameData.cy - 5f && objectToFollow.transform.position.y < gameData.cy + 5f)
            {
                transform.position = new Vector3(transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            }
            if (objectToFollow.transform.position.x > gameData.cx - 1.1f && objectToFollow.transform.position.x < gameData.cx + 1.1f && !(objectToFollow.transform.position.y > gameData.cy - 5f && objectToFollow.transform.position.y < gameData.cy + 5f))
            {
                transform.position = new Vector3(objectToFollow.transform.position.x, transform.position.y, transform.position.z);
            }

            }

    }
    public void refresh()
    {
        if (objectToFollow ?? false)
            transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
    }
}
