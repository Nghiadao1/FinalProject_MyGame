using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ItemConfix", menuName = "Item/ItemConfix")]
public class ItemConfix : ScriptableObject
{
    public List<Items> items;
}
[Serializable]
public class Items
{
    public ItemInBox itemInBox;
    public Sprite itemImage;
}