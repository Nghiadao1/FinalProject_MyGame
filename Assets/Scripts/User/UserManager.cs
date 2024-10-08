using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DatabaseManager;

public class UserManager : TemporaryMonoSingleton<UserManager>
{
    private PlayfabManager playfabManager => PlayfabManager.Instance;
    public ItemData ItemData;
    public ItemShop[] itemShops;
    public string coins;
    private void Awake()
    {
        itemShops = ItemData.itemShops;
        for (int i = 0; i < itemShops.Length; i++)
        {
            // Example usage of GetUserData with callback
            var  key = itemShops[i].name.ToString();
            // playfabManager.GetUserData(key, 
            //     (value) => {
            //         Debug.Log("Successfully retrieved Level: " + value);
            //     },
            //     (error) => {
            //         Debug.LogError("Failed to retrieve data: " + error);
            //     }
            // );
        }
    }
    public static int GetPriceItem(ItemType itemType)
    {
        var itemShop = Array.Find(Instance.itemShops, x => x.name == itemType);
        return itemShop.price;
    }
    public static int GetCountItem(ItemType itemType)
    {
        var itemShop = Array.Find(Instance.itemShops, x => x.name == itemType);
        return itemShop.count;
    }
    public void UpdateCountItem(ItemType itemType, int count)
    {
        var itemShop = Array.Find(Instance.itemShops, x => x.name == itemType);
        itemShop.count += count;
        //SaveData<int>(itemType.ToString(), itemShop.count);
        playfabManager.SavePlayerData(itemType.ToString(), itemShop.count.ToString());
    }
    private void OnApplicationQuit()
    {
        for (int i = 0; i < itemShops.Length; i++)
        {
            // SaveData<ItemShop>(DatabaseKey.ItemShop + i, itemShops[i]);
            playfabManager.SavePlayerData(itemShops[i].name.ToString(), itemShops[i].count.ToString());
        }
    }
}


