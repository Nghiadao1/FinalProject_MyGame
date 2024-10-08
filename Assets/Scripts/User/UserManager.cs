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
        itemShops = new ItemShop[ItemData.itemShops.Length];
        itemShops = ItemData.itemShops;
        StartCoroutine(LoadDataUser());
    }

    private IEnumerator LoadDataUser()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < itemShops.Length; i++)
        {
            // Example usage of GetUserData with callback
            var  key = itemShops[i].name.ToString();
            playfabManager.GetUserData(key,
                (result) =>
                {
                    itemShops[i].count = int.Parse(result);
                },
                (error) =>
                {
                    Debug.Log(error);
                });
            yield return new WaitForSeconds(0.5f);
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


