using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerInput))]
public class FishController : MonoBehaviour
{
    FishMovement fishMovement;
    AnimationControl fishAnimation;


    private void Awake()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.playerControls.Gamepad.PressButtonSouth.performed += OnPressButtonSouth;
        playerInput.playerControls.Gamepad.ReleaseButtonSouth.performed += OnReleaseButtonSouth;
        playerInput.playerControls.Gamepad.MoveLeftStick.performed += OnMoveLeftStick;
    }

    private void Start()
    {
        fishMovement = GetComponent<FishMovement>();
        fishAnimation = GetComponent<AnimationControl>();
    }

    private void OnPressButtonSouth(CallbackContext ctx)
    {
        fishMovement.PushForward();
        fishAnimation.AnimateFishForward();
    }

    private void OnReleaseButtonSouth(CallbackContext ctx){
        fishAnimation.AnimateFishIdle();
    }

    private void OnMoveLeftStick(CallbackContext ctx)
    {
        Vector2 rotation = ctx.ReadValue<Vector2>();
        fishMovement.SetRotation(rotation);
    }
}