using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Boar : MonoBehaviour
{
    private CharacterManager _characterManager => CharacterManager.Instance;
    [SerializeField] private Collider2D _enemyCollider;
    
    public int healthPoint;
    [SerializeField] private int attackPoint;
    [SerializeField] protected float speed;
    [SerializeField] private bool isAtack;

    public int OppAttackPoint;
    
    public Scrollbar healthBar;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    private int _CurrHealthPoint;
    
    private void Start()
    {
        Move();
        Init();
    }

    private void Update()
    {
        UpdateHeathBarPosition();
    }
    private void Init()
    {
        InitHearts();
        OppAttackPoint = _characterManager.attackPoint;
    }
    public void Move()
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
        if(other.CompareTag("Player"))
             Debug.Log("Player");
        
        if (other.CompareTag("HitAttack"))
        {
            Debug.Log("HitAttack");
            healthPoint -= OppAttackPoint;
            UpdateHearts();
            if (healthPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    private void InitHearts()
    {
        _CurrHealthPoint = healthPoint;
        healthBar.size = healthPoint;
    }
    private void UpdateHearts()
    {
        healthBar.size = (float)healthPoint / _CurrHealthPoint;
    }
    private void UpdateHeathBarPosition()
    {
        //update health bar position follow this enemy position not use camera position
        healthBar.transform.position = new Vector3(transform.position.x + 500f, healthBar.transform.position.y, healthBar.transform.position.z);
        
        
    }
    
}
