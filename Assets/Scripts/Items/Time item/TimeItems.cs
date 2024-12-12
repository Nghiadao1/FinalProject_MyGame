using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using static UserManager;

public class TimeItems : MonoBehaviour
{
    private UserManager UserManager => UserManager.Instance;
    public static Action OnUseTimeItem = delegate { };
    [SerializeField] private TMP_Text timeItemText;
    private int _totalTimeItem;
    // private void Awake()
    // {
    //     ListenEvent();
    // }
    //
    // private void OnDestroy()
    // {
    //     UnListenEvent();
    // }

    private void OnEnable()
    {
        var countItem = GetCountItem(ItemType.Time);
        _totalTimeItem = countItem;
        timeItemText.text = _totalTimeItem.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            UseTimeItem();
        }
    }

    public void UseTimeItem()
    {
        if(_totalTimeItem <=0) return;
        _totalTimeItem -= 1;
        timeItemText.text = _totalTimeItem.ToString();
        OnUseTimeItem?.Invoke();
        UserManager.UpdateCountItem(ItemType.Time, -1);
    }

    // private void ListenEvent()
    // {
    //     HPBottle.OnCollected += UpdateHPBottle;
    // }
    // private void UnListenEvent()
    // {
    //     //HPBottle.OnCollected -= UpdateHPBottle;
    // }
    // private void UpdateHPBottle(int hpBottle)
    // {
    //     UserManager.UpdateCountItem(ItemType.HP, hpBottle);
    //     var hpBottleBonus = _totalHPBottle + hpBottle;
    //     _totalHPBottle = hpBottleBonus;
    //     hpBottletext.text = _totalHPBottle.ToString();
    //     
    // }
}
