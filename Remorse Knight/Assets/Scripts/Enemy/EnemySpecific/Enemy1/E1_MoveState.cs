using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : EnemyMoveState
{
    private Enemy1 enemy;
    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, MoveStateData moveStateData,Enemy1 enemy) : base(entity, stateMachine, animBoolName, moveStateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        /*da vidim da napravim isto neki random movement na odredjeno vreme i jos neke ideje*/
        base.LogicUpdate();
        if (isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
