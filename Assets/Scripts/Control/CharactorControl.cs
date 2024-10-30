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
    public static Action<bool> OnShield = delegate {  };
    private CharacterManager characterManager;
    public bool isMove;
    public Button HitButon;
    public Button JumpButton;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        
    }
    
    public void Move(float x)
    {
        JumpButton.interactable = true;
        OnMove?.Invoke(x, true);
    }
    
    public void StopMove()
    {
        OnMove?.Invoke(0, false);
    }

    public void Jump()
    {
        JumpButton.interactable = false;
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
    public void Shield()
    {
        OnShield?.Invoke(true);
    }
}
