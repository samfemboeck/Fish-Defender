using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Script for handling Input. By default input is allowed from EVERY device.
 * That's why you need to RestrictToDevice() where necessary.
 */
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