using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : State
{

    protected MoveStateData moveStateData;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isPlayerInMinAggroRange;

    public EnemyMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, MoveStateData moveStateData) : base(entity, stateMachine, animBoolName)
    {
        this.moveStateData = moveStateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.Checkwall();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(moveStateData.movementSpeed);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {

        base.PhysicsUpdate();

    }
}
