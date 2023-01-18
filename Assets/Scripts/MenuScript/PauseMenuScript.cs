using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenuUi;
    public GameObject akt;
    [SerializeField] GameData gameData;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = !IsPaused;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().enabled = !IsPaused;

    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1.0f;
        IsPaused = false;

    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        //akt.GetComponent<TextMeshProUGUI>().text= "AKT nr. " + gameData.bossMeter.ToString();
        akt.GetComponent<TextMeshProUGUI>().SetText("AKT nr. " + gameData.bossMeter.ToString());
        //akt.text = "AKT nr. " + gameData.bossMeter.ToString();
    }
}
