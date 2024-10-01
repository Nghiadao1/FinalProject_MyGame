using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using static UserManager;

public class HPBottleText : MonoBehaviour
{
    public static Action OnUseHPBottle = delegate { };
    [SerializeField] private TMP_Text hpBottletext;
    private int _totalHPBottle;
    private void Awake()
    {
        ListenEvent();
    }

    private void OnDestroy()
    {
        UnListenEvent();
    }

    private void OnEnable()
    {
        var hpBottle = GetCountItem(ItemType.HP);
        _totalHPBottle = hpBottle;
        hpBottletext.text = _totalHPBottle.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            UseHpBottle();
        }
    }

    public void UseHpBottle()
    {
        if(_totalHPBottle <=0) return;
        _totalHPBottle -= 1;
        hpBottletext.text = _totalHPBottle.ToString();
        OnUseHPBottle?.Invoke();
        UpdateCountItem(ItemType.HP, -1);
    }

    private void ListenEvent()
    {
        HPBottle.OnCollected += UpdateHPBottle;
    }
    private void UnListenEvent()
    {
        //HPBottle.OnCollected -= UpdateHPBottle;
    }
    private void UpdateHPBottle(int hpBottle)
    {
        UpdateCountItem(ItemType.HP, hpBottle);
        var hpBottleBonus = _totalHPBottle + hpBottle;
        _totalHPBottle = hpBottleBonus;
        hpBottletext.text = _totalHPBottle.ToString();
        
    }
}
