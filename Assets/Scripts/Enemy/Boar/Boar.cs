using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Boar : MonoBehaviour
{
    public static Action<int> OnCoinCollected = delegate {  };
    //private CharacterManager _characterManager => CharacterManager.Instance;
    private EnemyAnimation _enemyAnimation;
    [SerializeField] public Collider2D _enemyCollider;
    public int healthPoint;
    [SerializeField] private int attackPoint;
    [SerializeField] protected float speed;
    [SerializeField] public bool isAttack;
    [SerializeField] private int coinValue = 20;
    //public int OppAttackPoint => _characterManager.attackPoint;
    
    public Scrollbar healthBar;
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    private int _CurrHealthPoint;
    private bool movingEnd = true;
    private Rigidbody2D _rigidbody2D;
    
    private void OnEnable()
    {
        Init();
    }

    private void Update()
    {
        if(!isAttack) return;
        Move();
    }
    private void Init()
    {
        InitHearts();
        isAttack = true;
        _enemyAnimation = GetComponent<EnemyAnimation>();
        if(startPos == null) return;
        transform.position = startPos.position;
    }
    
    public void Move()
    {
        if(endPos == null) return;
        var target = movingEnd ? endPos.position : startPos.position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, target) < 0.1f)
        {
            FlipEnemy();
        }
    }

    private void FlipEnemy()
    {
        movingEnd = !movingEnd;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isAttack)
        {
            _enemyAnimation.UpdateAnimation(EnemyState.Idle);
            //CharacterManager.Instance.health -= attackPoint;
            isAttack = false;
            CharacterManager.Instance.TakeDame();
            FlipEnemy();
        }
        
        if (other.CompareTag("HitAttack"))
        {
            Debug.Log("HitAttack");
            isAttack = false;
            _enemyCollider.enabled = false;
            _enemyAnimation.UpdateAnimation(EnemyState.Hit);
            //healthPoint -= OppAttackPoint;
            healthPoint -= CharacterManager.Instance.attackPoint;
            if (healthPoint <= 0)
            {
                OnCoinCollected(coinValue);
                Destroy(gameObject);
            }
        }
    }
    public void HitComplete()
    {
        _enemyAnimation.UpdateAnimation(EnemyState.Walk);
        isAttack = true;
        _enemyCollider.enabled = true;
        Move();
    }
    
    private void InitHearts()
    {
        //_CurrHealthPoint = healthPoint;
        //healthBar.size = healthPoint;
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
