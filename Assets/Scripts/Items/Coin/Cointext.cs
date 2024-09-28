using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DatabaseManager;

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
      int coin = LoadData<int>(DatabaseKey.Coin);
      cointext.text = coin.ToString() ?? "0";
      _totalCoin = int.Parse(cointext.text);
   }

   private void ListenEvent()
   {
      Coin.OnCollected += UpdateCoin;
      Boar.OnCoinCollected += UpdateCoin;
      Cheat.OnCheatCoin += UpdateCoin;
      Shop.OnBuyItem += UpdateCoin;
   }
   private void UnListenEvent()
   {
      //Coin.OnCoinCollected -= UpdateCoin;
      Cheat.OnCheatCoin -= UpdateCoin;
      Shop.OnBuyItem -= UpdateCoin;
   }
   private void UpdateCoin(int coin)
   {
      var coinBonus = _totalCoin + coin;
      _totalCoin = coinBonus;
      UpdateText();
      SaveData(DatabaseKey.Coin, _totalCoin);
   }

   private void UpdateText()
   {
      cointext.text = _totalCoin.ToString();
   }
}
