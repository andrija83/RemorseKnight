using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State
{
    protected LookForPlayerStateData lookForPlayerStateData;
    protected bool turnImmediatly;
    protected bool isAllTurnsDone;
    protected bool isPlayerInMinAggroRange;
    protected bool isAllTurnsTimeDone;

    protected float lastTurnTime;
    protected int amountOfTurnsDone;


    public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, LookForPlayerStateData lookForPlayerStateData) : base(entity, stateMachine, animBoolName)
    {
        this.lookForPlayerStateData = lookForPlayerStateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
    }

    public override void Enter()
    {
        base.Enter();
        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;
        lastTurnTime = startTime;
        amountOfTurnsDone = 0;
        entity.SetVelocity(0f);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (turnImmediatly)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            turnImmediatly = false;
        }
        else if (Time.time >= lastTurnTime + lookForPlayerStateData.timeBetweenTurns && !isAllTurnsDone)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }
        if (amountOfTurnsDone >= lookForPlayerStateData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }
        if (Time.time >= lastTurnTime + lookForPlayerStateData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;

        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public void SetTurnImmediately(bool flip) => turnImmediatly = flip;

    
}
