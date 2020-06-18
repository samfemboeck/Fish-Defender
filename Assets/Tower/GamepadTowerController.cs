using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(PlayerInput))]
public class GamepadTowerController : MonoBehaviour, ITowerController
{
    [SerializeField]
    GameObjectSet towers;

    [SerializeField]
    [Range(0,1)]
    float tolerance = .3f;  // Joysticks tend to deliver inaccurate values

	public PlayerColor PlayerColor { get => GetComponent<PlayerColor>(); }

    private int activeTowerIndex = 0;
    private Tower activeTower;
    private Vector3 curDirection = Vector3.zero;
    private Vector3 newDirection = Vector3.zero;
    private bool isAiming = false;
    private PlayerInput playerInput;
    private float analogStickDeadzone = .1f;


    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.playerControls.Gamepad.PressDPad.performed += OnPressDPad;
        ClaimAvailableTower();
    }

    private void Update()
    {
        Vector2 rightStick = playerInput.playerControls.Gamepad.MoveRightStick.ReadValue<Vector2>();
        Vector2 leftStick = playerInput.playerControls.Gamepad.MoveLeftStick.ReadValue<Vector2>();

        Vector2 direction = (rightStick + leftStick).normalized;
        float length = Math.Min(1f, rightStick.magnitude + leftStick.magnitude);

        Vector2 value = direction * length;

        if (value.magnitude < analogStickDeadzone)
        {
            isAiming = false;
            value = Vector2.zero;
        }
        else
            isAiming = true;

        if (!activeTower.ActiveProjectile)
            return;

        newDirection = -new Vector3(value.x, 0, value.y);

        Debug.Log("debug aim old:" + curDirection.magnitude);
        Debug.Log("debug aim new:" + newDirection.magnitude);

        if (newDirection.magnitude + tolerance < curDirection.magnitude)
        {
            activeTower.ShootProjectile(curDirection);
            curDirection = Vector3.zero;
        }
        else
        {
            curDirection = newDirection;
            activeTower.SetAimDirection(curDirection);
        }
    }


    private void SetTowerIndex(int index)
    {
        if (index >= towers.Count)
            index = 0;
        else if (index < 0)
            index = towers.Count - 1;
        activeTowerIndex = index;
    }

    private void OnPressDPad(CallbackContext ctx)
    {
        if (isAiming) return;
        Vector2 value = ctx.ReadValue<Vector2>();
        int xDirection = (int)value.x;
        int index = activeTowerIndex + xDirection;
        SetTowerIndex(index);
        ClaimAvailableTower();
    }

    public void ClaimAvailableTower()
    {
        TowerDecorator decorator = new TowerDecorator(towers);

        while (!decorator.GetByIndex(activeTowerIndex).TryClaim(this))
            SetTowerIndex(++activeTowerIndex);

        if (activeTower)
            activeTower.Release();

        activeTower = decorator.GetByIndex(activeTowerIndex);
    }

    private void OnDestroy()
    {
        activeTower.Release();
    }
}

