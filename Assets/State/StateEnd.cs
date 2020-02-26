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

    PlayerInput playerInput;

    private void Start()
    {
        fishes.RemoveAll();
        towerPlayers.RemoveAll();
        collectibles.RemoveAll();

        playerInput = new PlayerInput();
        playerInput.playerControls.Keyboard.PressSpace.performed += OnPressSpace;
    }

    public void OnPressSpace(InputAction.CallbackContext ctx)
    {
        GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>().ChangeToScreen(selectRole);
    }
}
