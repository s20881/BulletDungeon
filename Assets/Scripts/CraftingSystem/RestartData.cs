using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartData : MonoBehaviour
{
    [SerializeField] GameData gameData;
    private PlayerItems itemData;
    private string savePath;
    // Start is called before the first frame update
    void Start()
    {
        itemData = GetComponent<PlayerItems>();
        savePath = Application.persistentDataPath + "/savedItems.save";
    }

    public void resetData()
    {
        var save = new SaveItems()
        {
            savedGel = 15,
            savedScrap = 20,
            savedMediGel = 1,
            savedGunpowder = 5,
            savedGrenades = 1,

            savedArmor = 0f,
            savedHealth = 100f
        };
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }
        gameData.isbossroom = false;
        gameData.bossMeter = 0;

        SceneManager.LoadScene("Lobby");
    }
}
