using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{

    private WeaponAttack weapon;
    private float velocityToSet;
    private bool setVelocity;
    private int xIntput;
    private bool shouldCheckFlip;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        weapon.EnterWeapon();
        setVelocity = false;
    }

    public override void Exit()
    {
        base.Exit();
        weapon.ExitWeapon();
    }



    public void SetWeapon(WeaponAttack weapon)
    {
        this.weapon = weapon;
        weapon.InitializeWeapon(this);
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAbilityDone = true;
    }
    public void SetPlayerVelocity(float velocity)
    {
        player.SetVelocityX(velocity * player.FacingDirection);
        velocityToSet = velocity;
        setVelocity = true;
    }
    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xIntput = player.InputHandler.NormalInputX;
        if (shouldCheckFlip)
        {
            player.CheckFlip(xIntput);

        }

        if (setVelocity)
        {
            player.SetVelocityX(velocityToSet * player.FacingDirection);
        }
    }
}
