using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private static List<Vector2> rooms;
    [SerializeField] GameData gameData;
    private void Awake()
    {
        gameData.spawnMeter = 0;
        gameData.enemMeter = 0;
        rooms = new List<Vector2>();
    }

    public static bool HasRoomAt(Vector3 position)
    {
        var pos = new Vector2((int)position.x, (int)position.y);
        if (rooms.Contains(pos))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void AssignRoom(Vector3 position)
    {
        var pos = new Vector2((int)position.x, (int)position.y);
        if (!rooms.Contains(pos))
        {
            rooms.Add(pos);
        }
    }
}
