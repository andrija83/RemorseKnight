using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Reference on current State we wanna be in 
 */


public class PlayerStateMachine 
{
    public PlayerState CurrentState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }
    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }



    
}
