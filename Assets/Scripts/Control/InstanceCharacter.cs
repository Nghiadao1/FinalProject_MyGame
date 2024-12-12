using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceCharacter : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private Transform characterParent;
    [SerializeField] private Transform characterSpawnPoint;
    
    private void Awake()
    {
        InstantiateCharacter();
    }
    private void InstantiateCharacter()
    {
        Instantiate(characterPrefab, characterSpawnPoint.position, Quaternion.identity, characterParent);
    }
}
