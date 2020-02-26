using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System;
using System.Collections.Generic;

public class DeviceManager
{
    public event EventHandler OnGamepadChange;
    public List<Gamepad> gamepads = new List<Gamepad>();

    public DeviceManager()
    {
        foreach (var device in InputSystem.devices)
        {
            if (device is Gamepad) gamepads.Add((Gamepad) device);
        }

        InputSystem.onDeviceChange += (device, change) => DeviceChanged(device, change);
    }

    ~DeviceManager()
    {
        InputSystem.onDeviceChange -= (device, change) => DeviceChanged(device, change);
    }

    void DeviceChanged(InputDevice device, InputDeviceChange change)
    {
        if (!(device is Gamepad))
            return;

        Gamepad gamepad = (Gamepad)device;

        OnGamepadChange?.Invoke(this, EventArgs.Empty);

        switch (change)
        {
            case InputDeviceChange.Disconnected:
            case InputDeviceChange.Reconnected:
                break;
            case InputDeviceChange.Added:
                gamepads.Add(gamepad);
                break;
            case InputDeviceChange.Removed:
                gamepads.Remove(gamepad);
                break;
            default:
                break;
        }
    }
}
