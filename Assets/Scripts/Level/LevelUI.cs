using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private LevelConfigure levelConfigure;
    [SerializeField] private Transform levelUIParent;
    [SerializeField] private GameObject levelUIPrefab;
    private void OnEnable()
    {
        //ClearOldLevelObj();
        LoadLevelUI();
    }
    private void ClearOldLevelObj()
    {
        foreach (Transform child in levelUIParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void LoadLevelUI()
    {
        ClearOldLevelObj();
        //Instantiate level UI prefab in level UI parent
        for (int i = 0; i < levelConfigure.mapConfigures.Count; i++)
        {
            var levelUI = Instantiate(levelUIPrefab, levelUIParent);
            levelUI.SetActive(true);
            levelUI.GetComponent<LevelInfo>();
            levelUI.GetComponent<LevelInfo>().levelIndex = i;
        }
    }
}
