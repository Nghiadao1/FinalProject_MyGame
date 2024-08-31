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
    // [SerializeField] private Transform startPos;
    // [SerializeField] private Transform endPos;
    private void Start()
    {
        Init();
        Move();
    }
    private void Init()
    {
        
    }
    
    public virtual void Move()
    {
        // var scale = transform.localScale;
        // //move from startPos to endPos by speed and DoTween
        // transform.DOMove(startPos.position, speed).OnComplete(() =>
        // {
        //     transform.localScale = new Vector3(transform.localScale.x * -1, scale.y, scale.z);
        //     transform.DOMove(endPos.position, speed).OnComplete(() =>
        //     {
        //         Move();
        //         transform.localScale = new Vector3(transform.localScale.x * -1, scale.y, scale.z);
        //     });
        // });
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Character");
    }
}
