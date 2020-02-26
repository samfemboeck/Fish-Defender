using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class FishController : MonoBehaviour, IHavePlayerInput
{
    FishMovement fishMovement;

    public PlayerInput PlayerInput { get; set; }

    private void Awake()
    {
        PlayerInput = new PlayerInput();
        PlayerInput.playerControls.Fish.PressButtonSouth.performed += OnPressButtonSouth;
        PlayerInput.playerControls.Fish.MoveLeftStick.performed += OnMoveLeftStick;
    }

    private void Start()
    {
        fishMovement = GetComponent<FishMovement>();
    }

    private void OnDestroy()
    {
        PlayerInput.Disable();
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