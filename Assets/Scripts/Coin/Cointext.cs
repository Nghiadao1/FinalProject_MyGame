using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cointext : MonoBehaviour
{
   [SerializeField] private TMP_Text cointext;
   private int _totalCoin;
   private void Awake()
   {
      ListenEvent();
   }

   private void OnDestroy()
   {
      UnListenEvent();
   }

   private void Start()
   {
      _totalCoin = 0;
      cointext.text = _totalCoin.ToString();
   }

   private void ListenEvent()
   {
      Coin.OnCollected += UpdateCoin;
      Boar.OnCoinCollected += UpdateCoin;
   }
   private void UnListenEvent()
   {
      //Coin.OnCoinCollected -= UpdateCoin;
   }
   private void UpdateCoin(int coin)
   {
      var coinBonus = _totalCoin + coin;
      _totalCoin = coinBonus;
      cointext.text = _totalCoin.ToString();
   }
}
