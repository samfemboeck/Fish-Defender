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

    private int activeTowerIndex = 0;
    private Tower activeTower;
    private Vector3 curDirection = Vector3.zero;

    private void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.playerControls.Gamepad.PressDPad.performed += OnPressDPad;
        playerInput.playerControls.Gamepad.MoveLeftStick.performed += OnMoveStick;
        playerInput.playerControls.Gamepad.MoveRightStick.performed += OnMoveStick;
        ClaimAvailableTower();
    }

	public PlayerColor PlayerColor { get => GetComponent<PlayerColor>();}

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

    private void OnMoveStick(CallbackContext ctx)
    {
        if (!activeTower.ActiveProjectile)
            return;

        Vector2 value = ctx.ReadValue<Vector2>();
        Vector3 newDirection = -new Vector3(value.x, 0, value.y);

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
}

