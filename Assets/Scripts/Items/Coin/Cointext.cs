using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cointext : MonoBehaviour
{
   [SerializeField] private TMP_Text cointext;
   private int _totalCoin;
   private void OnEnable()
   {
      ListenEvent();
      Init();
   }

   private void OnDisable()
   {
      UnListenEvent();
   }
   

   private void Init()
   {
      cointext.text = DatabaseManager.LoadData<string>(DatabaseManager.DatabaseKey.Coin);
      _totalCoin = int.Parse(cointext.text);
   }

   private void ListenEvent()
   {
      Coin.OnCollected += UpdateCoin;
      Boar.OnCoinCollected += UpdateCoin;
      Cheat.OnCheatCoin += UpdateCoin;
   }
   private void UnListenEvent()
   {
      //Coin.OnCoinCollected -= UpdateCoin;
      Cheat.OnCheatCoin -= UpdateCoin;
   }
   private void UpdateCoin(int coin)
   {
      var coinBonus = _totalCoin + coin;
      _totalCoin = coinBonus;
      cointext.text = _totalCoin.ToString();
      DatabaseManager.SaveData(DatabaseManager.DatabaseKey.Coin, _totalCoin.ToString());
   }
}
