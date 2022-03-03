using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Scriptable Object For Player Data
 */

[CreateAssetMenu(fileName ="newPlayerData",menuName ="Data/PlayerData/Base Data")]
public class PlayerData : ScriptableObject
{

    [Header("Move State")]
    public float movementVeclocity = 10f;


    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;


    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;
    public float wallCheckDistance = 0.5f;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;


    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;

    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20f;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("Ledge Clmb State")]
    public Vector2 startOffSet;
    public Vector2 stopOffSet;

    [Header("Dash State")]
    public float dashCooldown = 0.5f;
    public float maxHoldTime = 1f;
    public float holdTimeScale = 0.25f;
    public float dashTime = 0.2f;
    public float dashVelocity = 2f;
    public float drag = 10f;
    public float dashEndYMultiplier = 0.2f;
    public float distanceBetweenAfterImages = 0.5f;

    [Header("AfterImage")]
    public float distBetweenAfterImages = 0.2f;

}
