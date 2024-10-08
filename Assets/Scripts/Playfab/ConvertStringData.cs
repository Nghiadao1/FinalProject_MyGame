using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertStringData : MonoBehaviour
{
    //convert class ItemData to string
    public static string ConvertItemDataToString(ItemData itemData)
    {
        string result = "";
        foreach (var item in itemData.itemShops)
        {
            result += item.name + "," + item.price + "," + item.count + "/";
        }
        return result;
    }
    //convert string to json string
    public static string ConvertStringToJsonString(string data)
    {
        return JsonUtility.ToJson(data);
    }
    //convert json string to string
    public static string ConvertJsonStringToString(string data)
    {
        return JsonUtility.FromJson<string>(data);
    }

    public static void ConvertToJson(ItemData itemData)
    {
        var data = ConvertItemDataToString(itemData);
        var jsonData = ConvertStringToJsonString(data);
        Debug.Log(jsonData);
    }
    public static void ConvertToString(string data)
    {
        var jsonData = ConvertJsonStringToString(data);
        Debug.Log(jsonData);
    }
}
