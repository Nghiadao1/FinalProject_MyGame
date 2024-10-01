using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData")]
public class ItemData : ScriptableObject
{
    public ItemShop[] itemShops;
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
    Time,
    Shield,
    test
}

