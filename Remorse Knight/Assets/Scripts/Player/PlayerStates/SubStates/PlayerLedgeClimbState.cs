using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Da popravim offset, animaciju da nadjem da mi napravi neko za climb edge i da vidim tilemaps colider */


public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 detectedPosition;
    private Vector2 cornerPostition;
    private Vector2 startPos;
    private Vector2 stopPos;
    private bool isHanging;
    private int xInput;
    private int yInput;
    private bool isClimbing;
    private bool jumpInput;
    private Vector2 workspace;



    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    //public override void AnimationFinishTrigger()
    //{
    //    base.AnimationFinishTrigger();
    //    player.Anim.SetBool("climbLedge", false);
    //}

    //public override void AnimationTrigger()
    //{
    //    base.AnimationTrigger();
    //    isHanging = true;
    //}

    //public override void Enter()
    //{
    //    base.Enter();
    //    core.Movement.SetVelocityZero();
    //    player.transform.position = detectedPosition;
    //    cornerPostition = player.DetermineCornerPostition();
    //    startPos.Set(cornerPostition.x - (core.Movement.FacingDirection * playerData.startOffSet.x), cornerPostition.y - playerData.startOffSet.y);
    //    stopPos.Set(cornerPostition.x + (core.Movement.FacingDirection * playerData.stopOffSet.x),cornerPostition.y + playerData.stopOffSet.y);
    //    player.transform.position = startPos;



    //}

    //public override void Exit()
    //{
    //    base.Exit();
    //    isHanging = false;
    //    if (isClimbing)
    //    {
    //        player.transform.position = stopPos;
    //        isClimbing = false;
    //    }
    //}

    //public override void LogicUpdate()
    //{
    //    base.LogicUpdate();
    //    if (isAnimationFinished)
    //    {
    //        stateMachine.ChangeState(player.IdleState);
    //    }
    //    else
    //    {
    //        core.Movement.SetVelocityZero();
    //        player.transform.position = startPos;
    //        xInput = player.InputHandler.NormalInputX;
    //        yInput = player.InputHandler.NormalInputY;
    //        jumpInput == player.InputHandler.JumpInput;
    //
    //
    //        if (xInput == core.Movement.FacingDirection && isHanging && !isClimbing)
    //        {
    //            isClimbing = true;
    //            player.Anim.SetBool("climbLedge", true);
    //        }
    //        else if (yInput == -1 && isHanging && !isClimbing)
    //        {
    //            stateMachine.ChangeState(player.InAirState);
    //        }else if (jumpInput && !isClimbing)
    //        {  
    //          player.WallJumpState.DetermineWallJumpDirection(true);
    //          stateMachine.ChangeState(player.WallJumpState);
    //        }
    //
    //    }

    //}

    //public void SetDetectedPostition(Vector2 postition) => detectedPosition = postition;

    //public Vector2 DetermineCornerPostition()
    //{
    //    RaycastHit2D xHit = Physics2D.Raycast(wallCheck.position, Vector2.right * Core.Movement.FacingDirection, playerData.wallCheckDistance, playerData.whatIsGround);
    //    float xDistance = xHit.distance;
    //    workspace.Set(xDistance * Core.Movement.FacingDirection, 0);
    //    RaycastHit2D yHit = Physics2D.Raycast(ledgeCheck.position + (Vector3)(workspace), Vector2.down, ledgeCheck.position.y - wallCheck.position.y, playerData.whatIsGround);
    //    float yDist = yHit.distance;
    //    workspace.Set(wallCheck.position.x + (xDistance * Core.Movement.FacingDirection), ledgeCheck.position.y - yDist);
    //    return workspace;

    //}

}
