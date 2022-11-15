using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{

    public void PLayGame()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
