using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
    protected PlayerDetectedData stateData;
    protected bool isPlayerInMinAggroRange;
    protected bool isPlayerInMaxAggroRange;

    public PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, PlayerDetectedData stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
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

        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
    }
}
