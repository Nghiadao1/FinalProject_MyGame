using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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

    private void Start()
    {
        _totalHPBottle = 0;
        hpBottletext.text = _totalHPBottle.ToString();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(_totalHPBottle <=0) return;
            _totalHPBottle -= 1;
            hpBottletext.text = _totalHPBottle.ToString();
            OnUseHPBottle?.Invoke();
        }
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
        var hpBottleBonus = _totalHPBottle + hpBottle;
        _totalHPBottle = hpBottleBonus;
        hpBottletext.text = _totalHPBottle.ToString();
    }
}
