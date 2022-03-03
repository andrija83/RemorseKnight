using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * State Objects Creator 
 */
public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerState playerState { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public InputPLayer InputHandler { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    //public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    public Transform DashDirectionIndicator { get; private set; }   

    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    //DEbugging 
    public bool isTouchingWalls;
    public bool isGrounded;


    [SerializeField] private PlayerData playerData;
    private Vector2 workspace;


    //Check Variables
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, "wallGrab");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
        WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "wallClimb");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
        DashState = new PlayerDashState(this, StateMachine, playerData, "inAir"); // da vidim da napravim custom animaciju za dash 
        //LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, "ledgeClimbState");

    }
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<InputPLayer>();
        RB = GetComponent<Rigidbody2D>();
        FacingDirection = 1;
        StateMachine.Initialize(IdleState);
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");
    }

    // Update is called once per frame
    void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
        Debug.Log(CheckIfGrounded());
        isTouchingWalls = CheckIfTouchingWall();
        isGrounded = CheckIfGrounded();

    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;

    }
    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void SetVelocity(float velocity,Vector2 direction)
    {
        workspace = direction * velocity;
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void SetVelocityZero()
    {
        RB.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;

    }



    public void CheckFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }
    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }
    public bool CheckIfTouchingWallBack()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    }
    //public bool CheckIfTouchingLedge()
    //{
    //    return Physics2D.Raycast(ledgeCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    //}

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0, 180, 0);
    }
    public Vector2 DetermineCornerPostition()
    {
        RaycastHit2D xHit = Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
        float xDistance = xHit.distance;
        workspace.Set(xDistance * FacingDirection, 0);
        RaycastHit2D yHit = Physics2D.Raycast(ledgeCheck.position + (Vector3)(workspace), Vector2.down, ledgeCheck.position.y - wallCheck.position.y, playerData.whatIsGround);
        float yDist = yHit.distance;
        workspace.Set(wallCheck.position.x + (xDistance * FacingDirection), ledgeCheck.position.y - yDist);
        return workspace;
        
    }



    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        string _stateText = StateMachine.CurrentState.ToString();

        GUIStyle customStyle = new GUIStyle();
        customStyle.fontSize = 30;   // can also use e.g. <size=30> in Rich Text
        customStyle.richText = true;
        Vector3 textPosition = transform.position + (Vector3.up * 0.3f);
        string richText = "<color=red><B>" + _stateText + "</B></color>";

        UnityEditor.Handles.Label(textPosition, richText, customStyle);


        GUIStyle customStyle1 = new GUIStyle();
        customStyle.fontSize = 15;   // can also use e.g. <size=30> in Rich Text
        customStyle.richText = true;
        Vector3 textPosition1 = transform.position + (Vector3.down * 1f);
        string richText1 = "<color=red><B>" + isGrounded + "</B></color> <color=red><B>" + isTouchingWalls + "</B></color>";

        UnityEditor.Handles.Label(textPosition1, richText1, customStyle1);


    }


    
}
