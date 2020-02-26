using UnityEngine;

public class StateSelectRole : MonoBehaviour
{
    [SerializeField]
    GameObject menuPlayerPrefab;

    [SerializeField]
    Screen gameplay;

    public int LockedPlayers { get; set; }
    DeviceManager deviceManager;

    private void Start()
    {
        LockedPlayers = 0;
        deviceManager = new DeviceManager();

        for (int i = 0; i < deviceManager.gamepads.Count; i++)
        {
            GameObject menuPlayer = GetComponent<ObjectSpawner>().SpawnAtPosition(menuPlayerPrefab, Vector3.zero);
            menuPlayer.transform.SetParent(transform);
            menuPlayer.GetComponent<IHavePlayerInput>().PlayerInput.RestrictToDevice(deviceManager.gamepads[i]);
        }
    }

    public void OnPlayerLock(GameObject player)
    {
        MenuPlayer menuPlayer = player.GetComponent<MenuPlayer>();
        ObjectSpawner spawner = GetComponent<ObjectSpawner>();
        GameObject role = spawner.SpawnAtRandomPosition(menuPlayer.GetRolePrefab());
        role.GetComponent<PlayerColor>().color = player.GetComponent<PlayerColor>().color;
        role.GetComponent<IHavePlayerInput>().PlayerInput.RestrictToDevice(menuPlayer.PlayerInput.device);

        if (++LockedPlayers >= deviceManager.gamepads.Count)
            GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>().ChangeToScreen(gameplay);
    }
}
