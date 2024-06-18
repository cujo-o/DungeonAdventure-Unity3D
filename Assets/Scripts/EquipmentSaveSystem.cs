using System.IO;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;

public static class EquipmentSaveSystem
{
   public static void SaveEquipment(equipmentSysytem equipmentSysytem)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Eq.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        Equipmentdata data = new Equipmentdata(equipmentSysytem);
        Debug.Log("saved");
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static Equipmentdata loadequipment()
    {
        string path = Application.persistentDataPath + "/Eq.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Debug.Log("loaded");
            Equipmentdata data = formatter.Deserialize(stream) as Equipmentdata;
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
