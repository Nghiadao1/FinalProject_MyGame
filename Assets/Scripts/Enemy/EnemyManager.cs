using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Collider2D _enemyCollider;
    
    [SerializeField] private int healthPoint;
    [SerializeField] private int attackPoint;
    [SerializeField] protected float speed;
    [SerializeField] private bool isAtack;
    
    private void Start()
    {
        Init();
        Move();
    }

    private void Init()
    {
        
    }

    protected virtual void Move()
    {
        Debug.Log("Move");
    }
}
