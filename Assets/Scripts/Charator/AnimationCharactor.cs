using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharactor : TemporaryMonoSingleton<AnimationCharactor>
{
    [SerializeField] private Animator animator;
    public Stage _stage;
    public void SetAnimation()
    {
        if(_stage.IsIdle)
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsJump", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsDead", false);
            animator.SetBool("IsHit", false);
        }
        
        if(_stage.IsDead)
        {
            animator.SetBool("IsDead", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsJump", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsHit", false);
            
        }
        if(_stage.IsRun)
        {
            animator.SetBool("IsRun", true);
            animator.SetBool("IsJump", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsDead", false);
            animator.SetBool("IsHit", false);
            
        }
        if(_stage.IsJump)
        {
            animator.SetBool("IsJump", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsDead", false);
            animator.SetBool("IsHit", false);
            
        }
        
        if(_stage.IsAttack)
        {
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsJump", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsDead", false);
            animator.SetBool("IsHit", false);
        }
        if(_stage.IsHit)
        {
            animator.SetBool("IsHit", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsJump", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsDead", false);
            animator.SetBool("IsAttack", false);
        }
    }
    private void SetStage(StageState state)
    {
        _stage.SetStageState(state);
    }
    public void UpdateAnimation(StageState state)
    {
        SetStage(state);
        SetAnimation();
    }
}
