using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boar : EnemyManager
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    
    public override void Move()
    {
        var scale = transform.localScale;
        //move from startPos to endPos by speed and DoTween
        transform.DOMove(startPos.position, speed).OnComplete(() =>
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, scale.y, scale.z);
            transform.DOMove(endPos.position, speed).OnComplete(() =>
            {
                Move();
                transform.localScale = new Vector3(transform.localScale.x * -1, scale.y, scale.z);
            });
        });
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other == CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
        }
        Debug.Log("Character");
    }
}
