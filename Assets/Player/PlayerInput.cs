using UnityEngine.InputSystem;

public class PlayerInput
{
    public PlayerControls playerControls;
    public InputDevice device;

    void Init()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();
    }

    public void Disable()
    {
        playerControls.Disable();
    }

    public PlayerInput()
    {
        Init();
    }

    public void RestrictToDevice(InputDevice target)
    {
        InputDevice targetDevice = null;

        foreach (var device in InputSystem.devices)
        {
            if (device == target)
                targetDevice = device;
        }

        playerControls.devices = new[] { targetDevice };
        device = targetDevice;
    }
}