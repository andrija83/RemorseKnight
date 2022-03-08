using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChargeState : State
{
    protected ChargeStateData chargeStateData;
    protected bool isPlayerInMinAggroRange;
    protected bool isDetectingLedge;
    protected bool isDetectingWall;
    protected bool isChargeTimeOver;
    protected bool isPlayerInMaxAggroRange;
    protected bool performCloseRangeAction;



    public EnemyChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, ChargeStateData chargeStateData) : base(entity, stateMachine, animBoolName)
    {
        this.chargeStateData = chargeStateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isDetectingLedge = entity.CheckLedge();
        isDetectingLedge = entity.Checkwall();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();


    }

    public override void Enter()
    {
        
        base.Enter();
        isChargeTimeOver = false;
        entity.SetVelocity(chargeStateData.chargeSpeed);
        

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime +  chargeStateData.chargeTime)
        {
            isChargeTimeOver = true;

        }

        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }
}
