using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    /// <summary>
    /// This save my player
    /// </summary>
    /// <param name="newCar"></param>
    /// <param name="bestScore"></param>
    public static void SavePlayer(int newCar, int bestScore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(newCar, bestScore);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    /// <summary>
    /// this load my player
    /// </summary>
    /// <returns></returns>
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file to found in " + path);
            return null;
        }
    }
}
