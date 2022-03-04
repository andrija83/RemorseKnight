using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;

    public Transform GroundCheck { get => groundCheck; private set => groundCheck = value; }
    public Transform WallCheck { get => wallCheck; private set => wallCheck = value; }
    public Transform LedgeCheck { get => ledgeCheck; private set => ledgeCheck = value; }


    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float wallCheckDistance;
    public float GroundCheckRadius { get => groundCheckRadius; set => groundCheckRadius = value; }
    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }
    public float WallCheckDistance { get => wallCheckDistance; set => wallCheckDistance = value; }


    public bool Ground
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public bool WallFront
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }
    public bool WallBack
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * -core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    }
    //public bool CheckIfTouchingLedge()
    //{
    //    return Physics2D.Raycast(ledgeCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
    //}


}
