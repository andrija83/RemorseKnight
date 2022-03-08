using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleAttackState : EnemyAttackState
{
    protected EnemyMeleAttackStateData enemyMeleAttackStateData;
    protected AttackDetails attackDetails;
    public EnemyMeleAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, EnemyMeleAttackStateData enemyMeleAttackStateData) : base(entity, stateMachine, animBoolName, attackPosition)
    {
        this.enemyMeleAttackStateData = enemyMeleAttackStateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        attackDetails.damageAmount = enemyMeleAttackStateData.attackDamage;
        attackDetails.position = entity.aliveGO.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, enemyMeleAttackStateData.attackRadius, enemyMeleAttackStateData.whatIsPlayer);


        foreach (var collider in detectedObjects)
        {
            collider.transform.SendMessage("Damage", attackDetails);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
