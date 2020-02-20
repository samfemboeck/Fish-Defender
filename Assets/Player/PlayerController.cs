using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public abstract class PlayerController : MonoBehaviour
{
    protected PlayerControls inputActions;

    private void OnEnable()
    {
        inputActions = new PlayerControls();
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable(); 
    }
}