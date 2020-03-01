using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class MenuPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject fishPlayerPrefab;

    [SerializeField]
    GameObject towerPlayerPrefab;

    [SerializeField]
    GameEvent OnPlayerLock;

    [SerializeField]
    GameEvent OnPlayerSwitch;

    public bool isFish;

    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerInput.playerControls.MenuPlayer.SwitchRole.performed += OnSwitchRole;
        playerInput.playerControls.MenuPlayer.LockRole.performed += OnLockRole;
    }

    public void OnLockRole(InputAction.CallbackContext obj)
    {
        playerInput.enabled = false;
        OnPlayerLock.Raise(gameObject);
    }

    public void OnSwitchRole(InputAction.CallbackContext ctx)
    {
        isFish = !isFish;
        OnPlayerSwitch.Raise(gameObject);
    }

    public GameObject GetRolePrefab()
    {
        if (isFish)
            return fishPlayerPrefab;
        else
            return towerPlayerPrefab;
    }
}
