using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    [SerializeField] GameData gameData;
    private void Update()
    {
        if (gameData.isbossroom)
        {
            if (objectToFollow.transform.position.x >  - 1.7f && objectToFollow.transform.position.x <  1.7f && objectToFollow.transform.position.y >  - 6f && objectToFollow.transform.position.y < + 6f)
            {
                transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            }
            if (!(objectToFollow.transform.position.x > - 1.7f && objectToFollow.transform.position.x <  1.7f && objectToFollow.transform.position.y >  - 6f && objectToFollow.transform.position.y <   6f))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            if (!(objectToFollow.transform.position.x > - 1.7f && objectToFollow.transform.position.x <  1.7f) && objectToFollow.transform.position.y >  - 6f && objectToFollow.transform.position.y <   6f)
            {
                transform.position = new Vector3(transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            }
            if (objectToFollow.transform.position.x >  - 1.7f && objectToFollow.transform.position.x <  1.7f && !(objectToFollow.transform.position.y >  - 6f && objectToFollow.transform.position.y <   6f))
            {
                transform.position = new Vector3(objectToFollow.transform.position.x, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (objectToFollow.transform.position.x > gameData.cx - 1.7f && objectToFollow.transform.position.x < gameData.cx + 1.7f && objectToFollow.transform.position.y > gameData.cy - 6f && objectToFollow.transform.position.y < gameData.cy + 6f)
            {
                transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            }
            if (!(objectToFollow.transform.position.x > gameData.cx - 1.7f && objectToFollow.transform.position.x < gameData.cx + 1.7f && objectToFollow.transform.position.y > gameData.cy - 6f && objectToFollow.transform.position.y < gameData.cy + 6f))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            if (!(objectToFollow.transform.position.x > gameData.cx - 1.7f && objectToFollow.transform.position.x < gameData.cx + 1.7f) && objectToFollow.transform.position.y > gameData.cy - 6f && objectToFollow.transform.position.y < gameData.cy + 6f)
            {
                transform.position = new Vector3(transform.position.x, objectToFollow.transform.position.y, transform.position.z);
            }
            if (objectToFollow.transform.position.x > gameData.cx - 1.7f && objectToFollow.transform.position.x < gameData.cx + 1.7f && !(objectToFollow.transform.position.y > gameData.cy - 6f && objectToFollow.transform.position.y < gameData.cy + 6f))
            {
                transform.position = new Vector3(objectToFollow.transform.position.x, transform.position.y, transform.position.z);
            }
        }
            



    }
    public void refresh()
    {
        transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, transform.position.z);
    }
}
