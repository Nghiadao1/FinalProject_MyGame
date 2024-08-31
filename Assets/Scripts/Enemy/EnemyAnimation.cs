using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
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
            animator.SetBool("IsDead", false);
        }

        if (enemyStage.IsRun)
        {
            animator.SetBool("IsRun", true);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsDead", false);
        }
        if(enemyStage.IsWalk)
        {
            animator.SetBool("IsWalk", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            animator.SetBool("IsDead", false);
        }
        if(enemyStage.IsAttack)
        {
            animator.SetBool("IsAttack", true);
            animator.SetBool("IsRun", false);
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsDead", false);
        }
        if(enemyStage.IsDead)
        {
            animator.SetBool("IsDead", true);
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
    private void UpdateAnimation(EnemyState state)
    {
        SetStage(state);
        SetAnimation();
    }
    
}

public enum EnemyState
{
    Attack,
    Dead,
    Run,
    Walk,
    Idle
}
public class EnemyStage
{
    public EnemyState CurrentState { get; private set; }
    
    public void SetStageState(EnemyState state)
    {
        CurrentState = state;
    }

    public bool IsAttack => CurrentState == EnemyState.Attack;
    public bool IsDead => CurrentState == EnemyState.Dead;
    public bool IsRun => CurrentState == EnemyState.Run;
    public bool IsWalk => CurrentState == EnemyState.Walk;
    public bool IsIdle => CurrentState == EnemyState.Idle;
}
