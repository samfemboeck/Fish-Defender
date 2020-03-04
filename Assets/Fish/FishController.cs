using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerInput))]
public class FishController : MonoBehaviour
{
    FishMovement fishMovement;

    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.playerControls.Gamepad.PressButtonSouth.performed += OnPressButtonSouth;
        playerInput.playerControls.Gamepad.MoveLeftStick.performed += OnMoveLeftStick;
    }

    private void Start()
    {
        fishMovement = GetComponent<FishMovement>();
    }

    private void OnPressButtonSouth(CallbackContext ctx)
    {
        fishMovement.PushForward();
    }

    private void OnMoveLeftStick(CallbackContext ctx)
    {
        Vector2 rotation = ctx.ReadValue<Vector2>();
        fishMovement.SetRotation(rotation);
    }
}