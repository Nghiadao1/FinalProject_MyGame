using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigure", menuName = "Level/LevelConfigure")]
public class LevelConfigure : ScriptableObject
{
    public List<MapConfigure> mapConfigures;
}
[Serializable]
public class MapConfigure
{
    public string mapName;
    public GameObject mapPrefab;
    public Vector3 mapPosition;
    public Vector3 mapRotation;
    public Vector3 mapScale;
    public bool isMapActive;
    public Vector3 CharatorPosition;
}
