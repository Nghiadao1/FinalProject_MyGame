using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DatabaseManager;

public class Cointext : MonoBehaviour
{
   private PlayfabManager PlayfabManager => PlayfabManager.Instance;
   private GetValuePlayfab GetValuePlayfab => GetValuePlayfab.Instance;
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
      var key = KeyPlayfab.Coins.ToString();
      GetValuePlayfab.GetValue(key);
      cointext.text = UserManager.Instance.coins;
      _totalCoin = int.Parse(cointext.text);
   }

   private void ListenEvent()
   {
      Coin.OnCollected += UpdateCoin;
      Boar.OnCoinCollected += UpdateCoin;
      Cheat.OnCheatCoin += UpdateCoin;
      Shop.OnBuyItem += UpdateCoin;
      UpgradeShop.OnUpgrade += UpdateCoin;
   }
   private void UnListenEvent()
   {
      //Coin.OnCoinCollected -= UpdateCoin;
      Cheat.OnCheatCoin -= UpdateCoin;
      Shop.OnBuyItem -= UpdateCoin;
      UpgradeShop.OnUpgrade -= UpdateCoin;
   }
   private void UpdateCoin(int coin)
   {
      var coinBonus = _totalCoin + coin;
      _totalCoin = coinBonus;
      
      UpdateText();
      var key = KeyPlayfab.Coins.ToString();
      PlayfabManager.SavePlayerData(key, _totalCoin.ToString());
   }

   private void UpdateText()
   {
      cointext.text = _totalCoin.ToString();
   }
}
