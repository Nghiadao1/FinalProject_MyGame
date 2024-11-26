using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static DatabaseManager;
using static UpgradeManager;

public class UpgradeShop : MonoBehaviour
{ 
    private GetValuePlayfab GetValuePlayfab => GetValuePlayfab.Instance;
    private UpgradeManager UpgradeManager => UpgradeManager.Instance;
    public static Action<int> OnUpgrade = delegate { };
    [SerializeField] int price;
    [SerializeField] int value;
    [SerializeField] int data;
    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private TMP_Text valueText;
    private int _currentValue;
    private void OnEnable()
    {
        Init();
    }
    private void Init()
    {
        price = GetPriceUpgrade(upgradeType);
        value = GetValueUpgrade(upgradeType);
        UpdadeData();
    }
    private void UpdadeData()
    {
        data = GetDataUpgrade(upgradeType);
        _currentValue = data;
        var configValue = 0;
        if(upgradeType == UpgradeType.health) configValue = 100;
        else if(upgradeType == UpgradeType.attackPoint) configValue = 5;
        else if(upgradeType == UpgradeType.DEF) configValue = 0;
        valueText.text = "+ " + (_currentValue + configValue).ToString();
    }
    public void Upgrade()
    {
        var key = KeyPlayfab.Coins.ToString();
        var coinTxt = UserManager.Instance.coins;
        var coin = int.Parse(coinTxt);
        if (coin < price) return;
        OnUpgrade(-price);
        UpgradeManager.UpdateValueUpgrade(upgradeType, value);
        UpdadeData();
    }
}


