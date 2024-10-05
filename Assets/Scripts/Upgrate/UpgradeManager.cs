using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DatabaseManager;

public class UpgradeManager : TemporaryMonoSingleton<UpgradeManager>
{
    public UpgradeConfigure upgradeConfigure;
    public Upgrade[] upgrades;

    private void Awake()
    {
        upgrades = upgradeConfigure.upgrades;
        for (int i = 0; i < upgrades.Length; i++)
        {
            upgrades[i].data = LoadData<int>(upgrades[i].upgradeType.ToString(),"0");
        }
    }
    public static int GetPriceUpgrade(UpgradeType upgradeType)
    {
        var upgrade = Array.Find(Instance.upgrades, x => x.upgradeType == upgradeType);
        return upgrade.price;
    }
    public static int GetValueUpgrade(UpgradeType upgradeType)
    {
        var upgrade = Array.Find(Instance.upgrades, x => x.upgradeType == upgradeType);
        return upgrade.value;
    }
    public static int GetDataUpgrade(UpgradeType upgradeType)
    {
        var upgrade = Array.Find(Instance.upgrades, x => x.upgradeType == upgradeType);
        return upgrade.data;
    }
    public static void UpdateValueUpgrade(UpgradeType upgradeType, int value)
    {
        var upgrade = Array.Find(Instance.upgrades, x => x.upgradeType == upgradeType);
        upgrade.data += value;
        SaveData<int>(upgradeType.ToString(), upgrade.data);
    }
}
