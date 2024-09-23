using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactorControl : TemporaryMonoSingleton<CharactorControl>
{
    public static Action<float, bool> OnMove = delegate {  };
    public static Action<bool> OnJump = delegate {  };
    public static Action<bool> OnAttack = delegate {  };
    public static Action<bool> OnSkill = delegate {  };
    private CharacterManager characterManager;
    public bool isMove;
    public Button HitButon;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        
    }
    
    public void Move(float x)
    {
        OnMove?.Invoke(x, true);
    }
    
    public void StopMove()
    {
        OnMove?.Invoke(0, false);
    }

    public void Jump()
    {
        OnJump?.Invoke(true);
    }
    public void Attack()
    {
        if(!HitButon.interactable) return;
        OnAttack?.Invoke(true);
    }
    public void Skill()
    {
        OnSkill?.Invoke(true);
    }
}
