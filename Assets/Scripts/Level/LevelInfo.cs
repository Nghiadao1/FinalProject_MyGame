using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    private LevelManager LevelManager => LevelManager.Instance;
    public int levelIndex;
    [SerializeField] private TMP_Text NameLevel;
    [SerializeField] private TMP_Text NameLevelButton;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        NameLevel.text = (levelIndex + 1).ToString();
        NameLevelButton.text = "Level " + (levelIndex + 1);
    }
    public void OnSelectLevel()
    {
        LevelManager.levelIndex = levelIndex;
    }
}
