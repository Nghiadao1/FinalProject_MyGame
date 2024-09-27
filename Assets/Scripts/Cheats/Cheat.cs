using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public static Action<int> OnCheatCoin = delegate {  };
    public void CheatCoin()
    {
        var coin = 1000;
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.Coin, coin.ToString());
        OnCheatCoin(coin);
    }
}
