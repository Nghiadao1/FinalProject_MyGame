using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterManager : MonoBehaviour
{
    //Components
    private Rigidbody2D _rb;
    [SerializeField] private GameObject character;
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
    
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        IsGrounded();
        Move();
    }

    private void Init()
    {
         _rb = character.GetComponent<Rigidbody2D>();
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
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        character.transform.position += direction * speed * Time.deltaTime;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            _move.Jump(jumpForce, _rb, isGrounded);
        }
    }

    private bool CheckIsGrounded()
    {
        //check if the character is on the ground
        var hit = Physics2D.Raycast(transform.position, Vector2.down, distanceJump);
        return hit.collider != null;
    }
    private void IsGrounded()
    {
        isGrounded = CheckIsGrounded();
    }

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
