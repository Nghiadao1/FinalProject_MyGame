using System;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    // Enum to define the keys for PlayerPrefs
    public enum DatabaseKey
    {
        Level,
        Coin,
        ItemShop,
    }

    // Generic method to save data to PlayerPrefs
    public static void SaveData<T>(DatabaseKey key, T data)
    {
        string keyString = key.ToString();
        string dataString = string.Empty;
        var dataType = typeof(T);
        if (dataType.IsPrimitive || dataType == typeof(string))
        {
            dataString = data.ToString();
        }
        else
        {
            dataString = JsonUtility.ToJson(data);
        }
        PlayerPrefs.SetString(keyString, dataString);
        PlayerPrefs.Save();
        Debug.Log($"Save: {keyString}: {dataString}");
    }
    public static void SaveData<T>(string key, T data)
    {
        string keyString = key.ToString();
        string dataString = string.Empty;
        var dataType = typeof(T);
        if (dataType.IsPrimitive || dataType == typeof(string))
        {
            dataString = data.ToString();
        }
        else
        {
            dataString = JsonUtility.ToJson(data);
        }
        PlayerPrefs.SetString(keyString, dataString);
        PlayerPrefs.Save();
        Debug.Log($"Save: {keyString}: {dataString}");
    }
    // Generic method to load data from PlayerPrefs
    public static T LoadData<T>(DatabaseKey key, string defaultValue = "")
    {
        string keyString = key.ToString();
        string dataString = PlayerPrefs.GetString(keyString, defaultValue);
        if (PlayerPrefs.HasKey(keyString) || !string.IsNullOrEmpty(dataString))
        {
            Debug.Log($"Load: {keyString}: {dataString}");
            var dataType = typeof(T);
            if (dataType.IsPrimitive || dataType == typeof(string))
            {
                Debug.Log($"string data: {dataString}");
                return (T)Convert.ChangeType(dataString, typeof(T));
            }
            else
            {
                return JsonUtility.FromJson<T>(dataString);
            }
        }
        else
        {
            Debug.Log($"Load: {keyString}: default");
            return default(T);
        }
    }
    public static T LoadData<T>(string key, string defaultValue = "")
    {
        string keyString = key.ToString();
        string dataString = PlayerPrefs.GetString(keyString, defaultValue);
        if (PlayerPrefs.HasKey(keyString) || !string.IsNullOrEmpty(dataString))
        {
            Debug.Log($"Load: {keyString}: {dataString}");
            var dataType = typeof(T);
            if (dataType.IsPrimitive || dataType == typeof(string))
            {
                Debug.Log($"string data: {dataString}");
                return (T)Convert.ChangeType(dataString, typeof(T));
            }
            else
            {
                return JsonUtility.FromJson<T>(dataString);
            }
        }
        else
        {
            Debug.Log($"Load: {keyString}: default");
            return default(T);
        }
    }

    internal static T LoadData<T>(DatabaseKey sound, T v)
    {
        throw new NotImplementedException();
    }
    // Example usage
    // public static void ExampleUsage()
    // {
    //     // Save high score
    //     int highScore = 1000;
    //     SaveData(DatabaseKey.HighScore, highScore);

    //     // Load high score
    //     int loadedHighScore = LoadData<int>(DatabaseKey.HighScore);
    //     Debug.Log("High Score: " + loadedHighScore);

    //     // Save player name
    //     string playerName = "John Doe";
    //     //SaveData(DatabaseKey.PlayerName, playerName);

    //     // Load player name
    //     string loadedPlayerName = LoadData<string>(DatabaseKey.PlayerName);
    //     Debug.Log("Player Name: " + loadedPlayerName);
    // }

    public static T LoadData<T>(DatabaseKey key, ItemType[] itemType)
    {
        string keyString = key.ToString();
        string dataString = PlayerPrefs.GetString(keyString, itemType.ToString());
        if (PlayerPrefs.HasKey(keyString) || !string.IsNullOrEmpty(dataString))
        {
            Debug.Log($"Load: {keyString}: {dataString}");
            var dataType = typeof(T);
            if (dataType.IsPrimitive || dataType == typeof(string))
            {
                Debug.Log($"string data: {dataString}");
                return (T)Convert.ChangeType(dataString, typeof(T));
            }
            else
            {
                return JsonUtility.FromJson<T>(dataString);
            }
        }
        else
        {
            Debug.Log($"Load: {keyString}: default");
            return default(T);
        }
    }
}
