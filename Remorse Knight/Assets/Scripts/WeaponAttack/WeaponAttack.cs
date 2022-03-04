using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    protected Animator animator;
    protected PlayerAttackState attackState;
    protected int attackCounter;
    [SerializeField] private SO_WeaponData weaponData;

    protected virtual void Start()
    {
        animator = transform.Find("SwordWeapon").GetComponent<Animator>();
        gameObject.SetActive(false);
    }
    public virtual void EnterWeapon()
    {
        //mogu da napravim kad je razmak izmedju MouseClick recimo na 0.3 da vrati animaciju na prvi attack a ne da nastavi sa kombom
        if (attackCounter >= weaponData.movementSpeed.Length)
        {
            attackCounter = 0;
        }
        gameObject.SetActive(true);
        animator.SetBool("attack", true);


        animator.SetInteger("attackCounter",attackCounter);
    }
    public virtual void ExitWeapon()
    {
        animator.SetBool("attack", false);
        gameObject.SetActive(false);

        attackCounter++;
    }


    public virtual void AnimationFinishTrigger()
    {
        attackState.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        attackState.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);

    }

    public virtual void AnimationStopMovementTrigger()
    {
        attackState.SetPlayerVelocity(0f);
    }
    public virtual void AnimationTurnOffFlipTrigger()
    {
        attackState.SetFlipCheck(false);
    }
    public void AnimationTurnOnFlipTrigger()
    {
        attackState.SetFlipCheck(true);
    }



    public void InitializeWeapon(PlayerAttackState state)
    {
        this.attackState = state;
    }
}
