using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class TowerController : MonoBehaviour, IHavePlayerInput
{
    [SerializeField]
    [Range(0, 10)]
    int aimIndicatorRange;

    Tower[] towers;
    int curTowerIndex;
    bool canShoot;
    Vector2 curDirection;

    public Tower CurTower
    {
        get { return towers[curTowerIndex]; }
    }

    public PlayerInput PlayerInput { get; set; }

    private void Awake()
    {
        PlayerInput = new PlayerInput();
        PlayerInput.playerControls.Tower.PressDPad.performed += OnPressDPad;
        PlayerInput.playerControls.Tower.MoveStick.performed += OnMoveStick;
        PlayerInput.playerControls.Tower.EnableShooting.performed += OnEnableShooting;
        PlayerInput.playerControls.Tower.EnableShooting.canceled += OnDisableShooting;
    }

    private void Start()
    {
        towers = FindObjectsOfType<Tower>();
    }

    private void OnDestroy()
    {
        PlayerInput.Disable();
    }

    private void OnDisableShooting(CallbackContext ctx)
    {
        canShoot = false;
        CurTower.ShootProjectile(new Vector3().With(x: curDirection.x, z: curDirection.y));
    }

    private void OnEnableShooting(CallbackContext ctx)
    {
        canShoot = true;
    }

    private void OnPressDPad(CallbackContext ctx)
    {
        Vector2 value = ctx.ReadValue<Vector2>();
        int xDirection = (int) value.x;
        int index = curTowerIndex + xDirection;

        if (index >= towers.Length)
            index = 0;
        else if (index < 0)
            index = towers.Length - 1;

        curTowerIndex = index;
    }

    // TODO replace with polling mechanism as controller stick values are unreliable
    private void OnMoveStick(CallbackContext ctx)
    {
        if (!canShoot) return;

        curDirection = -(ctx.ReadValue<Vector2>());

        var curProjectile = CurTower.ActiveProjectile;
        var projectilePos = curProjectile.transform.position;
        curProjectile.GetComponent<LineRenderer>().SetPosition(0, projectilePos);
        curProjectile.GetComponent<LineRenderer>().SetPosition(1, projectilePos.With(x: projectilePos.x + (curDirection.x * aimIndicatorRange), z: projectilePos.z + (curDirection.y * aimIndicatorRange)));
    }
}