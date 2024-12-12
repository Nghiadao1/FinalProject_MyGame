using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DatabaseManager;
using static UserManager;
public class Shop : MonoBehaviour
{
    public static Action<int> OnBuyItem = delegate {  };
    private UserManager UserManager => UserManager.Instance;
    private GetValuePlayfab GetValuePlayfab => GetValuePlayfab.Instance;
    [SerializeField]private ItemType ItemName;
    [SerializeField] private TMP_Text textNumberItem;
    [SerializeField]private int Price;
    [SerializeField]private int Count;
    
    private void OnEnable()
    {
        Init();
    }

    private void Init()
    {
        Price = GetPriceItem(ItemName);
        Count = GetCountItem(ItemName);
        textNumberItem.text = Count.ToString() ?? "0";
    }
    public void BuyItem()
    {
        // var coin = LoadData<int>(DatabaseKey.Coin);
        var key = KeyPlayfab.Coins.ToString();
        //GetValuePlayfab.GetValue(key);
        var coinTxt = UserManager.coins;
        var coin = int.Parse(coinTxt);
        if(coin < Price) return;
        OnBuyItem(-Price);
        //Count++;
        UserManager.UpdateCountItem(ItemName,1);
        var item = GetCountItem(ItemName);
        textNumberItem.text = item.ToString();
    }
}
