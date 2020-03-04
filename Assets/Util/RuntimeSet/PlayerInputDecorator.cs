using UnityEngine;

/* 
 * A Decorator for GameObjectSets.
 * Allows you to Query GameObjectSets for PlayerInput Components
 */
public class PlayerInputDecorator : ComponentDecorator<PlayerInput>
{
    public PlayerInputDecorator(GameObjectSet set) : base(set)
    {
    }

    public PlayerInput GetByDeviceId(int deviceId)
    {
        foreach (GameObject g in set.items)
        {
            PlayerInput playerInput;
            if (TryGetComponent(g, out playerInput) && 
                playerInput.device != null && 
                playerInput.device.deviceId == deviceId)
                return playerInput;
        }
        return null;
    }
}
