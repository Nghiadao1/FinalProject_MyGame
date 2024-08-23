using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Serialization;

public class CharacterManager : MonoBehaviour
{
    //events
    //public static Action<int> AnimationActive = delegate {  };
    //Components
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private  Collider2D characterCollider2D;
    [SerializeField] private GameObject character;
    [SerializeField] private Animator animator;
    private Move _move;
    
    //Character info
    public CharacterInfo _characterInfo;
    public float jumpForce
    {
        get => _characterInfo.jumpForce;
        set => _characterInfo.jumpForce = value;
    }
    public float speed
    {
        get => _characterInfo.speed;
        set => _characterInfo.speed = value;
    }
    public int health
    {
        get => _characterInfo.health;
        set => _characterInfo.health = value;
    }
    public int attackPoint
    {
        get => _characterInfo.attackPoint;
        set => _characterInfo.attackPoint = value;
    }
    public float distanceJump
    {
        get => _characterInfo.distanceJump;
        set => _characterInfo.distanceJump = value;
    }

    //Stage Character
    public bool isGrounded;
    public Stage _stage;
    
    private void Start()
    {
        isGrounded = true;
        Init();
        SetAnimation();
    }

    private void Update()
    {
        //IsGrounded();
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
            character.transform.position += direction * speed * Time.deltaTime;
            if(!isGrounded) return;
            SetStage(StageState.Run);
            SetAnimation();
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
            FlipFollowDirection(1);
            character.transform.position += direction * speed * Time.deltaTime;
            if(!isGrounded) return;
            SetStage(StageState.Run);
            SetAnimation();
        }
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
            SetStage(StageState.Jump);
            SetAnimation();
        }
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetStage(StageState.Attack);
            SetAnimation();
        }
    }
    public void EndAttack()
    {
        IsGrounded();
        SetAnimation();
    }

    private bool CheckIsGrounded()
    {
        //check if the character is on the ground
        var hit = Physics2D.Raycast(transform.position, Vector2.down, distanceJump);
        return hit.collider != null;
    }
    public void IsGrounded()
    {
        isGrounded = CheckIsGrounded();
        SetStage(isGrounded ? StageState.Idle : StageState.Jump);
        SetAnimation();
    }
    private void CheckIdle()
    {
        //if charactor not move, set animation idle
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W)) && isGrounded)
        {
           SetStage(StageState.Idle);
           SetAnimation();
           //active animation idle using boolen in animator
        }
    }

    private void SetStage(StageState state)
    {
        _stage.SetStageState(state);
    }
    private void SetAnimation()
    {
        if(_stage.IsIdle)
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsJump", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsDead", false);
        }
        
        if(_stage.IsDead)
        {
            animator.SetBool("IsDead", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsJump", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            
        }
        if(_stage.IsRun)
        {
            animator.SetBool("IsRun", true);
            animator.SetBool("IsJump", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsDead", false);
            
        }
        if(_stage.IsJump)
        {
            animator.SetBool("IsJump", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsDead", false);
            
        }
        
        if(_stage.IsAttack)
        {
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsJump", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsDead", false);
        }
    }
}

public enum StageState
{
    Attack,
    Dead,
    Run,
    Jump,
    Idle
}
[Serializable]
public class Stage
{
    public StageState CurrentState { get; private set; }
    
    public void SetStageState(StageState state)
    {
        CurrentState = state;
        Debug.LogError("Atack: "+IsAttack+" Dead: "+IsDead+" Run: "+IsRun+" Jump: "+IsJump+" Idle: "+IsIdle);
    }

    public bool IsAttack => CurrentState == StageState.Attack;
    public bool IsDead => CurrentState == StageState.Dead;
    public bool IsRun => CurrentState == StageState.Run;
    public bool IsJump => CurrentState == StageState.Jump;
    public bool IsIdle => CurrentState == StageState.Idle;
}


[Serializable]
public class CharacterInfo
{
     public float speed;
     public float jumpForce;
     public int health;
     public int attackPoint;
     public float distanceJump;
}
