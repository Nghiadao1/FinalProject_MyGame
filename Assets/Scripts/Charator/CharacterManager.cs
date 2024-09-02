using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Serialization;

public class CharacterManager : TemporaryMonoSingleton<CharacterManager>
{
    //events
    private AnimationCharactor _animationCharactor => AnimationCharactor.Instance;
    //Components
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private  Collider2D characterCollider2D;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject attackHit;
    private Move _move;
    
    //Character info
    public CharactorInfo charactorInfo;
    public float jumpForce
    {
        get => charactorInfo.jumpForce;
        set => charactorInfo.jumpForce = value;
    }
    public float speed
    {
        get => charactorInfo.speed;
        set => charactorInfo.speed = value;
    }
    public int health
    {
        get => charactorInfo.health;
        set => charactorInfo.health = value;
    }
    public int attackPoint
    {
        get => charactorInfo.attackPoint;
        set => charactorInfo.attackPoint = value;
    }
    public float distanceJump
    {
        get => charactorInfo.distanceJump;
        set => charactorInfo.distanceJump = value;
    }

    //Stage Character
    public bool isGrounded;
    
    
    private void Start()
    {
        isGrounded = true;
        Init();
        _animationCharactor.SetAnimation();
    }

    private void Update()
    {
        Move();
        Attack();
        CheckIdle();
    }

    private void Init()
    {
         _move = character.GetComponent<Move>();
    }
    private void Move()
    {
        Jump();
        Run();
    }

    private void Run()
    {
        var direction = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
            FlipFollowDirection(-1);
            UpdateTransform(direction);
            if(!isGrounded) return;
            _animationCharactor.UpdateAnimation(StageState.Run);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            FlipFollowDirection(1);
            UpdateTransform(direction);
            if(!isGrounded) return;
            _animationCharactor.UpdateAnimation(StageState.Run);
        }
    }

    private void UpdateTransform(Vector3 direction)
    {
        character.transform.position += direction * speed * Time.deltaTime;
    }

    private void FlipFollowDirection(float x)
    {
        character.transform.localScale = new Vector3(x, 1, 1);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            _move.Jump(jumpForce, rb);
            isGrounded = false;
            _animationCharactor.UpdateAnimation(StageState.Jump);
        }
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _animationCharactor.UpdateAnimation(StageState.Attack);
            attackHit.SetActive(true);
            StartCoroutine(AttackCoroutine());
        }
    }
    //courotine for attack
    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        attackHit.SetActive(false);
    }
    public void EndAttack()
    {
        IsGrounded();
        _animationCharactor.SetAnimation();
    }

    private bool CheckIsGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, distanceJump);
        return hit.collider != null;
    }
    public void IsGrounded()
    {
        isGrounded = CheckIsGrounded();
        _animationCharactor.UpdateAnimation(isGrounded ? StageState.Idle : StageState.Jump);
    }
    private void CheckIdle()
    {
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W)) && isGrounded)
        {
            _animationCharactor.UpdateAnimation(StageState.Idle);
        }
    }
    
    
}





