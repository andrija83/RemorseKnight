using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//main class from which enemies will derive 
public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public EntityData entityData;

    public Rigidbody2D RB { get; private set; }
    public Animator animator { get; private set; }
    public GameObject aliveGO { get; private set; }
    public int facingDirection { get; private set; }

    private Vector2 velocityWorkspace;
    public LayerMask whatIsGround;


    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;

    public virtual void Start()
    {
        facingDirection = 1;
        aliveGO = transform.Find("Alive").gameObject;
        RB = aliveGO.GetComponent<Rigidbody2D>();
        animator = aliveGO.GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
    }
    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }
    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, RB.velocity.y);
        RB.velocity = velocityWorkspace;

    }
    public virtual bool Checkwall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }
    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);

    }
    public virtual bool CheckPlayerInMinAggroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAggroDistance, entityData.whatIsPlayer);
    }
    public virtual bool CheckPlayerInMaxAggroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAggroDistance, entityData.whatIsPlayer);

    }
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position,wallCheck.position + (Vector3) (Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down  * entityData.ledgeCheckDistance));

    }
    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0, 180, 0);

    }


}
