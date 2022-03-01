using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Base State All States Inherits From PlayerState
*/
public class PlayerState
{

    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    private string animBoolName; //what animation should be played
    protected float startTime;  //start of a state 
    protected bool isAnimationFinished;
    protected bool isExitingState; 

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    //gets called when we enter state
    public virtual void Enter()
    {
        DoChecks();      
        player.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        Debug.Log(animBoolName);
        isAnimationFinished = false;
        isExitingState = false;
    }
    //gets called when we exit state
    public virtual void Exit()
    {
        player.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }
    //gets called every frame
    public virtual void LogicUpdate()
    {

    }
    //gets called every fixed update
    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    //Check for ground,walls etc (no need to call it from every single state) 
    public virtual void DoChecks()
    {

    }
    public virtual void AnimationTrigger()
    {

    }
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
  

}
