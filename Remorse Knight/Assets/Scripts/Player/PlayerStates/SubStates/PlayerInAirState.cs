using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    //input
    private int xInput;
    private bool jumpInput;
    private bool jumpInputStop;
    private bool grabInput;
    private bool dashInput;


    //checks
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingWallBack;
    private bool oldIsTouchignWall;
    private bool oldIsTouchingWallback;
    private bool isTouchingLedge;

    private bool isJumping;
    private bool coyoteTime;
    private bool wallJumpCoyoteTime;


    private float startWallJumpCoyoteTime;


    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        oldIsTouchignWall = isTouchingWall;
        oldIsTouchingWallback = isTouchingWallBack;
        isGrounded = player.CheckIfGrounded();
        isTouchingWall = player.CheckIfTouchingWall();
        isTouchingWallBack = player.CheckIfTouchingWallBack();
        //isTouchingLedge = player.CheckIfTouchingLedge();
        //if (isTouchingWall && !isTouchingLedge)
        //{
        //    player.LedgeClimbState.SetDetectedPostition(player.transform.position);
        //}
        if (!wallJumpCoyoteTime && !isTouchingWall && !isTouchingWallBack && (oldIsTouchignWall || oldIsTouchingWallback))
        {          
            StartWallJumpCoyoteTime();
        }

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        oldIsTouchingWallback = false;
        oldIsTouchignWall = false;
        isTouchingWall = false;
        isTouchingWallBack = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckCoyoteTime();
        CHeckWallJumpCoyoteTime();

        xInput = player.InputHandler.NormalInputX;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;
        grabInput = player.InputHandler.GrabInput;
        dashInput = player.InputHandler.DashInput;

        CheckJumpMultiplier();

        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        //else if (isTouchingWall && !isTouchingLedge && !isGrounded)
        //{
        //    stateMachine.ChangeState(player.LedgeClimbState);
        //}
        else if (jumpInput && (isTouchingWall || isTouchingWallBack || wallJumpCoyoteTime))
        {
            StopWallJumpCoyoteTime();
            isTouchingWall = player.CheckIfTouchingWall();
            player.WallJumpState.DetermineWallJumpDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (isTouchingWall && grabInput /* && isTouchingLedge */  )
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if (isTouchingWall && xInput == player.FacingDirection && player.CurrentVelocity.y <= 0)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
        else if (dashInput && player.DashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
        else
        {
            player.CheckFlip(xInput);
            player.SetVelocityX(playerData.movementVeclocity * xInput);
            player.Anim.SetFloat("yvelocity", player.CurrentVelocity.y);
        }
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                player.SetVelocityY(player.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (player.CurrentVelocity.y <= 0f)
            {
                isJumping = false;
            }
        }
    }
    private void CheckCoyoteTime()
    {
        if (coyoteTime == true && Time.time > startWallJumpCoyoteTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreseAmountOfJumpsLeft();
        }
    }
    private void CHeckWallJumpCoyoteTime()
    {
        if (wallJumpCoyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            wallJumpCoyoteTime = false;
        }
    }
    public void StartWallJumpCoyoteTime()
    {
        wallJumpCoyoteTime = true;
        startWallJumpCoyoteTime = Time.time;
    }
    public void StopWallJumpCoyoteTime() => wallJumpCoyoteTime = false;

    public void StartCoyoteTime() => coyoteTime = true;
    public void SetIsJumping() => isJumping = true;

}
