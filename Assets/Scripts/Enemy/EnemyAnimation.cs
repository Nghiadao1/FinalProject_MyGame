using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : TemporaryMonoSingleton<EnemyAnimation>
{
    [SerializeField] private Animator animator;
    public EnemyStage enemyStage;

    private void SetAnimation()
    {
        if(enemyStage.IsIdle)
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsHit", false);
        }

        if (enemyStage.IsRun)
        {
            animator.SetBool("IsRun", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsHit", false);
        }
        if(enemyStage.IsWalk)
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsHit", false);
        }
        if(enemyStage.IsAttack)
        {
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsHit", false);
        }
        if(enemyStage.IsHit)
        {
            animator.SetBool("IsHit", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsIdle", false);
        }
    }
    private void SetStage(EnemyState state)
    {
        enemyStage.SetStageState(state);
    }
    public void UpdateAnimation(EnemyState state)
    {
        SetStage(state);
        SetAnimation();
    }
    
}

public enum EnemyState
{
    Attack,
    Hit,
    Run,
    Walk,
    Idle
}
[Serializable]
public class EnemyStage
{
    public EnemyState CurrentState { get; private set; }
    
    public void SetStageState(EnemyState state)
    {
        CurrentState = state;
    }

    public bool IsAttack => CurrentState == EnemyState.Attack;
    public bool IsHit => CurrentState == EnemyState.Hit;
    public bool IsRun => CurrentState == EnemyState.Run;
    public bool IsWalk => CurrentState == EnemyState.Walk;
    public bool IsIdle => CurrentState == EnemyState.Idle;
}
