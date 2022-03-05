using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : State
{

    protected MoveStateData moveStateData;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;

    public EnemyMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, MoveStateData moveStateData) : base(entity, stateMachine, animBoolName)
    {
        this.moveStateData = moveStateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(moveStateData.movementSpeed);
        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.Checkwall();

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

        isDetectingLedge = entity.CheckLedge();
        isDetectingWall = entity.Checkwall();
    }
}
