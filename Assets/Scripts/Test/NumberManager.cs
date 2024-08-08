using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    private SupperUp _supperUp => SupperUp.Instance;
    private int _number = 0;
    [SerializeField] private Text numberText;

    private void Awake()
    {
        NumberUp.ClickUpNumber += UpNumber;
        NumberUp.ClickDownNumber += DownNumber;
    }
    
    private void OnDestroy()
    {
        NumberUp.ClickUpNumber -= UpNumber;
    }
    
    public void SupperDown()
    {
        _supperUp.SuperDown();
    }

    private void UpNumber(int num)
    {
        if (_number >= 50)
        {
            _number += _supperUp.supper;
            numberText.text = _number.ToString();
            return;
        }
        _number+=num;
        numberText.text = _number.ToString();
    }
    private void DownNumber()
    {
        if (_number == 0) return;
        _number--;
        numberText.text = _number.ToString();
    }
}
