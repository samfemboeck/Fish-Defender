using UnityEngine;

public class PlayerInputDecorator : RuntimeSetDecorator<GameObject>
{
    public PlayerInputDecorator(RuntimeSet<GameObject> runtimeSet) : base(runtimeSet)
    {
    }

    public PlayerInput GetByDeviceId(int deviceId)
    {
        foreach (GameObject g in runtimeSet.items)
        {
            PlayerInput playerInput = g.GetComponent<PlayerInput>();

            if (!playerInput || playerInput.device == null)
                continue;
            else if (playerInput.device.deviceId == deviceId)
                return playerInput;
        }
        return null;
    }
}
