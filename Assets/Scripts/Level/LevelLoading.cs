using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoading : MonoBehaviour
{
    private LevelManager LevelManager => LevelManager.Instance;
    public LevelConfigure levelConfigure;
    private int LevelIndex => LevelManager.levelIndex;
    [SerializeField] private GameObject character;
    private void Start()
    {
        LoadLevel();
    }
    
    private void LoadLevel()
    {
        var targetMap = levelConfigure.mapConfigures[LevelIndex];
        var map = Instantiate(targetMap.mapPrefab, targetMap.mapPosition, Quaternion.Euler(targetMap.mapRotation));
        map.transform.localScale = targetMap.mapScale;
        map.SetActive(true);
        
        var position = targetMap.CharatorPosition;
        character.transform.position = position;
    }
}
