using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stage
{
    public StageState CurrentState { get; private set; }
    
    public void SetStageState(StageState state)
    {
        CurrentState = state;
        //Debug.LogError("Atack: "+IsAttack+" Dead: "+IsDead+" Run: "+IsRun+" Jump: "+IsJump+" Idle: "+IsIdle);
    }

    public bool IsAttack => CurrentState == StageState.Attack;
    public bool IsDead => CurrentState == StageState.Dead;
    public bool IsRun => CurrentState == StageState.Run;
    public bool IsJump => CurrentState == StageState.Jump;
    public bool IsIdle => CurrentState == StageState.Idle;
}
