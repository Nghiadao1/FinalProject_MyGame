using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DatabaseManager;

public class UpgradeManager : TemporaryMonoSingleton<UpgradeManager>
{
    private PlayfabManager PlayfabManager => PlayfabManager.Instance;
    public UpgradeConfigure upgradeConfigure;
    public Upgrade[] upgrades;

    private void Awake()
    {
        upgrades = upgradeConfigure.upgrades;
        StartCoroutine(LoadDataUpgrade());
    }

    private IEnumerator LoadDataUpgrade()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < upgrades.Length; i++)
        {
            var key = upgrades[i].upgradeType.ToString();
            PlayfabManager.GetUserData(key,
                (result) =>
                {
                    upgrades[i].data = int.Parse(result);
                },
                (error) =>
                {
                    Debug.Log(error);
                });
            yield return new WaitForSeconds(0.5f);
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
    public void UpdateValueUpgrade(UpgradeType upgradeType, int value)
    {
        var upgrade = Array.Find(Instance.upgrades, x => x.upgradeType == upgradeType);
        upgrade.data += value;
        var key = upgradeType.ToString();
        PlayfabManager.SavePlayerData(key, upgrade.data.ToString());
        
    }
    
}
