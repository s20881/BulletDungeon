using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(PlayerItems))]
public class SaveScript : MonoBehaviour
{
    private PlayerItems itemData;
    private string savePath;
    // Start is called before the first frame update
    void Start()
    {
        itemData = GetComponent<PlayerItems>();
        savePath = Application.persistentDataPath + "/savedItems.save";
        loadData();
    }

    public void saveData()
    {
        var save = new SaveItems()
        {
            savedGel = itemData.gel,
            savedScrap = itemData.scrap,
            savedMediGel = itemData.MediGel,
            savedGunpowder = itemData.gunpowder,
            savedGrenades = itemData.Grenades,

            savedArmor = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().armor,
            savedHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().initialHealth
        };
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }
    }

    public void loadData()
    {
        if (File.Exists(savePath))
        {
            SaveItems save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (SaveItems) binaryFormatter.Deserialize(fileStream);
            }

            itemData.gel = save.savedGel;
            itemData.scrap = save.savedScrap;
            itemData.MediGel = save.savedMediGel;
            itemData.gunpowder = save.savedGunpowder;
            itemData.Grenades = save.savedGrenades;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().armor = save.savedArmor;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().initialHealth = save.savedHealth;
        }
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
        loadData();
    }
}
