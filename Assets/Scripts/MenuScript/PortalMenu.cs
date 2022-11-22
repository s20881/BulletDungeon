using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PortalMenu : MonoBehaviour
{
    [SerializeField] GameData gameData;
    public GameObject panel;
    private void Update()
    {
        if (gameData.PortalPenl)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
    public void Go()
    {
        Time.timeScale = 1f;
        if (!gameData.isbossroom)
        {

            SceneManager.LoadScene("BossScene");
            gameData.isbossroom = true;
        }
        else
        {
            if (gameData.bossMeter == 2)
            {
                SceneManager.LoadScene("EndScene");
            }
            else
            {
                SceneManager.LoadScene("RoomScene");
                gameData.isbossroom = false;
                gameData.level += 0.15f;
                gameData.levelenem -= 0.15f;
                gameData.bossMeter += 1;
            }

        }
        gameData.PortalPenl = false;
    }
    public void Stop()
    {
        Time.timeScale = 1f;
        gameData.PortalPenl = false;
    }
}
