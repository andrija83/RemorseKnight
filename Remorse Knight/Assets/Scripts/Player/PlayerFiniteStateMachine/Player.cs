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
    public Animator Anim { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public InputPLayer InputHandler { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    [SerializeField] private PlayerData playerData;



    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
    }
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
        InputHandler = GetComponent<InputPLayer>();
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        Debug.Log(InputHandler.MovementInput);

    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
