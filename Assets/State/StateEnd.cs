using UnityEngine;
using UnityEngine.InputSystem;

public class StateEnd : MonoBehaviour
{
    [SerializeField]
    Screen selectRole;

    [SerializeField]
    GameObjectSet fishes;

    [SerializeField]
    GameObjectSet towerPlayers;

    [SerializeField]
    GameObjectSet collectibles;

    private void Start()
    {
        fishes.RemoveAll();
        towerPlayers.RemoveAll();
        collectibles.RemoveAll();

        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.playerControls.Keyboard.PressSpace.performed += OnPressSpace;
    }

    public void OnPressSpace(InputAction.CallbackContext ctx)
    {
        ScreenManager.Instance.ChangeToScreen(selectRole);
    }
}
