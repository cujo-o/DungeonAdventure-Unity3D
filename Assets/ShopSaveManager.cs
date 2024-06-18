using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ShopSaveManager : MonoBehaviour
{
    public static ShopSaveManager instance { get; private set; }

    //What we want to save
    public int currentCarr;
    public int money;
    public bool[] carsUnlocked = new bool[9] { false, false, false, false, false, false, false, false, false };
    public bool equip;


    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(gameObject);
        Load();
        
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfoo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfoo.dat", FileMode.Open);
            ShopData_Storage data = (ShopData_Storage)bf.Deserialize(file);

            currentCarr = data.currentCarr;
            money = data.money;
          equip=data.equip;
            carsUnlocked = data.carsUnlocked;

            if (data.carsUnlocked == null)
                carsUnlocked = new bool[9] { false, false, false, false, false, false, false, false, false };

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfoo.dat");
        ShopData_Storage data = new ShopData_Storage();

        data.currentCarr = currentCarr;
        data.money = money;
        data.carsUnlocked = carsUnlocked;
        data.equip = equip;
        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class ShopData_Storage
{
    public int currentCarr;
    public int money;
    public bool[] carsUnlocked;
    public bool equip;
}