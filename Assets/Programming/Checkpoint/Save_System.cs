using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save_System
{
    public static void Save_Player(Player_Store_Data player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player_data.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData playerData = new PlayerData(player);

        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData Load_Player()
    {
        string path = Application.persistentDataPath + "/player_data.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Savefile not found in " + path);
            return null;
        }
    }
}
