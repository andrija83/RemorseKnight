using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool canDash { get; private set; }
    private float lastDashTime;
    private bool isHolding;
    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;
    private bool dashInputStop;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        canDash = false;
        player.InputHandler.UseDashInput();
        isHolding = true;
        dashDirection = Vector2.right * player.FacingDirection;

        Time.timeScale = playerData.holdTimeScale; // za slowmotion efekt
        startTime = Time.unscaledTime; //da cooldown ide regularno vreme dok je slowmotion u efektu (TODO: da pogledam na ovu foru da napravim ability da zaustavi vreme da player moze da se pomera)
        player.DashDirectionIndicator.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
       if (player.CurrentVelocity.y > 0)
       {
            player.SetVelocityY(player.CurrentVelocity.y * playerData.dashEndYMultiplier);
       }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isExitingState)
        {
            if (isHolding)
            {
                dashDirectionInput = player.InputHandler.RawDashDirectionInput;
                dashInputStop = player.InputHandler.DashInputStop;
                if (dashDirectionInput != Vector2.zero)
                {
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }
                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

            }
            if (dashInputStop || Time.unscaledTime >= startTime + playerData.maxHoldTime)
            {
                isHolding = false;
                Time.timeScale = 1;
                startTime = Time.time;
                player.CheckFlip(Mathf.RoundToInt(dashDirection.x));
                player.RB.drag = playerData.drag;
                player.SetVelocity(playerData.dashVelocity, dashDirection);
                player.DashDirectionIndicator.gameObject.SetActive(false);
                isAbilityDone = true;

            }
        }
        else
        {
            player.SetVelocity(playerData.dashVelocity, dashDirection);
            
            if (Time.time >= startTime + playerData.dashTime)
            {
                player.RB.drag = 0f;
                isAbilityDone = true;
                lastDashTime = Time.time;
            }
        }

    }
    public bool CheckIfCanDash()
    {
        return canDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }
    public void ResetCanDash() => canDash = true;





}
