using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lobby_Dungeon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            SceneManager.LoadScene("Scenes/New Scene", LoadSceneMode.Single);
=======
            SceneManager.LoadScene("Scenes/RoomScene", LoadSceneMode.Single);
>>>>>>> Stashed changes
        }
    }
}
