using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HeathCharactor : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private TMP_Text textMeshPro;
    private int _maxHeath;
    private int _currentHeath;
    private void Start()
    {
        Init();
        ActiveEvent();
    }
    private void ActiveEvent()
    {
        CharacterManager.OnTakeDame += UpdateHeath;
    }

    private void Init()
    {
        _currentHeath = _maxHeath = CharacterManager.Instance.health;
        textMeshPro.text = $"{_currentHeath}/{_maxHeath}";
        scrollbar.size = 1;
    }

    private void UpdateHeath(int heath)
    {
        _currentHeath = heath;
        textMeshPro.text = $"{_currentHeath}/{_maxHeath}";
        scrollbar.size = (float)_currentHeath / _maxHeath;
    }
}
