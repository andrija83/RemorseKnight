using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPLayer : MonoBehaviour
{
    public Vector2 MovementInput { get; private set; }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        Debug.Log("MOVE");
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        Debug.Log("JUMP");
    }



    
}
