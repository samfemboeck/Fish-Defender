using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour 
{
    public PlayerControls playerControls;
    public InputDevice device;

    void OnEnable()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();
    }

    public void OnDisable()
    {
        playerControls.Disable();
    }

    public void RestrictToDevice(InputDevice target)
    {
        device = target;
        playerControls.devices = new[] { device };
    }
}