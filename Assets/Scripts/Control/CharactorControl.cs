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
    public Button SkillButton;
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
        if(JumpButton.interactable) return;
        JumpButton.interactable = true;
    }
    
    public void StopMove()
    {
        OnMove?.Invoke(0, false);
    }

    public void Jump()
    {
        JumpButton.interactable = false;
        OnJump?.Invoke(true);
        Invoke("ActiveButtonJump", 0.75f);
    }
    public void Attack()
    {
        if(!HitButon.interactable) return;
        OnAttack?.Invoke(true);
    }
    public void Skill()
    {
        SkillButton.interactable = false;
        OnSkill?.Invoke(true);
        Invoke("ActiveButtonSkill", 5f);
    }
    public void Shield()
    {
        OnShield?.Invoke(true);
    }
    
    private void ActiveButtonJump()
    {
        if(JumpButton.interactable) return;
        JumpButton.interactable = true;
    }
    private void ActiveButtonSkill()
    {
        if(SkillButton.interactable) return;
        SkillButton.interactable = true;
    }
}
