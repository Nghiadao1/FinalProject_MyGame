using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DatabaseManager;

public class UserManager : TemporaryMonoSingleton<UserManager>
{
    public ItemData ItemData;
    public ItemShop[] itemShops;

    private void Awake()
    {
        itemShops = ItemData.itemShops;
        for (int i = 0; i < itemShops.Length; i++)
        {
            itemShops[i].count = LoadData<int>(itemShops[i].name.ToString(),"0");
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
    public static void UpdateCountItem(ItemType itemType, int count)
    {
        var itemShop = Array.Find(Instance.itemShops, x => x.name == itemType);
        itemShop.count += count;
        SaveData<int>(itemType.ToString(), itemShop.count);
    }
    private void OnApplicationQuit()
    {
        for (int i = 0; i < itemShops.Length; i++)
        {
            SaveData<ItemShop>(DatabaseKey.ItemShop + i, itemShops[i]);
        }
    }
}
[Serializable]
public class ItemShop
{
    public ItemType name;
    public int price;
    public int count;
}

public enum ItemType
{
    HP,
    test
}

