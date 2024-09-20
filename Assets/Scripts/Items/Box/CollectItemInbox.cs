using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
[Serializable]
public class CollectItemInbox : MonoBehaviour
{
    public ItemInBox itemInBox;
    [SerializeField] public Image itemImage;
    [SerializeField] private ItemConfix itemConfix;
    private void OnEnable()
    {
        //random item in box
        itemInBox = (ItemInBox)UnityEngine.Random.Range(0, 3);
        InitItemImage(itemInBox);
    }

    private void InitItemImage(ItemInBox item)
    {
        foreach (var itemConfix in itemConfix.items)
        {
            if (itemConfix.itemInBox == item)
            {
                itemImage.sprite = itemConfix.itemImage;
            }
        }   
    }

    public void CollectItem()
    {   
        SceneManager.ClosePopup();
    }
    
}
public enum ItemInBox
{
    Coin,
    Heart,
    Key
}
