using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class CharacterManager : TemporaryMonoSingleton<CharacterManager>
{
    //Events
    public static Action<int> OnTakeDame = delegate {  };
    //Singleton
    private AnimationCharactor _animationCharactor => AnimationCharactor.Instance;
    private CharactorControl _charactorControl => CharactorControl.Instance;
    //Components
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject attackHit;
    [SerializeField] private LayerMask groundLayer;
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
    private float _x;
    public bool isMove;
    public bool isJump;
    public bool isAttack;
    private void Start()
    {
        
        Init();
        ActiveEvent();
    }
    private Button _hitButton => _charactorControl.HitButon;
    private void Update()
    {
        Move();
        Attack(isAttack);
        CheckIdle();
    }

    private void Init()
    {
        isGrounded = true;
        _animationCharactor.SetAnimation();
    }
    private void ActiveEvent()
    {
        CharactorControl.OnMove += Run;
        CharactorControl.OnJump += Jump;
        CharactorControl.OnAttack += Attack;
    }
    private void DeActiveEvent()
    {
        CharactorControl.OnMove -= Run;
        CharactorControl.OnJump -= Jump;
        CharactorControl.OnAttack -= Attack;
    }
    
    private void Move()
    {
        //Jump(isJump);
        Run(_x, isMove);
    }

    private void Run(float x, bool isMove)
    {
        if (!isMove)
        {
            this.isMove = false;
            IsGrounded();
            return;
        }
        _x = x;
        this.isMove = true;
        var direction = Vector3.zero;
        if (StartMove(ref direction, x)) return;
    }

    private bool StartMove(ref Vector3 direction, float x)
    {
        direction += new Vector3(x,0,0);
        FlipFollowDirection(x);
        UpdateTransform(direction);
        if(!isGrounded) return true;
        _animationCharactor.UpdateAnimation(StageState.Run);
        return false;
    }

    private void UpdateTransform(Vector3 direction)
    {
        character.transform.position += direction * speed * Time.deltaTime;
    }

    private void FlipFollowDirection(float x)
    {
        character.transform.localScale = new Vector3(x, 1, 1);
    }

    public void Jump(bool isJump)
    {
        if (!isJump || !isGrounded) return;
        isGrounded = false;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _animationCharactor.UpdateAnimation(StageState.Jump);
    }

    private void Attack(bool isAttack)
    {
        if (!isAttack) return;
        _hitButton.interactable = false;
        this.isAttack = true;
        _animationCharactor.UpdateAnimation(StageState.Attack);
        attackHit.SetActive(true);
    }
   
    public void EndAttack()
    {
        IsGrounded();
        _animationCharactor.SetAnimation();
        isAttack = false;
        attackHit.SetActive(false);
        _hitButton.interactable = true;
    }

    private bool CheckIsGrounded()
    {
        // check if the player is grounded with tag "Ground"
        var hit = Physics2D.Raycast(character.transform.position, Vector2.down, distanceJump, groundLayer);
        return hit.collider != null;
    }
    public void IsGrounded()
    {
        isGrounded = CheckIsGrounded();
        _animationCharactor.UpdateAnimation(isGrounded ? StageState.Idle : StageState.Jump);
    }
    private void CheckIdle()
    {
        if (isGrounded && !isMove && !isAttack)
        {
            _animationCharactor.UpdateAnimation(StageState.Idle);
        }
    }
    
    public void TakeDame()
    {
        // if (health <= 0)
        // {
        //     _animationCharactor.UpdateAnimation(StageState.Die);
        //     DeActiveEvent();
        //     return;
        // }
        health -= 10;
        OnTakeDame?.Invoke(health);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce*1.2f); 
        
    }
    
    
}





