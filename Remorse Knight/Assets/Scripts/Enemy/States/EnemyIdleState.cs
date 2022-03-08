using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    protected IdleStateData stateData;
    protected bool flipAfterIdle;
    protected float idleTime;
    protected bool isIdleTimeOver;
    protected bool isPlayerInMinAggroRange;


    public EnemyIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, IdleStateData stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();

    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();
        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();


    }

    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }
}
