using System.IO;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;

public static class CoinSaveSystem
{
   public static void Savecoin(ShopManager shopManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        coindata data = new coindata(shopManager);
       // Debug.Log("saved");
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static coindata loadData()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            coindata data = formatter.Deserialize(stream) as coindata;
            stream.Close();
            return data;
               
        }
        else
        {
            Debug.LogError("file not found in " + path);
            return null;

        }
    }
    
    }
