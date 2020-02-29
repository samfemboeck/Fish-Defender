using UnityEngine;
using UnityEngine.InputSystem;

public class StateTitle : MonoBehaviour
{
    [SerializeField]
    GameObject menuPlayerPrefab;

    [SerializeField]
    Screen gameplay;

    public int LockedPlayers { get; set; }
    DeviceManager deviceManager;
    ScreenManager screenManager;
    public bool AllPlayersLocked { get; set; }

    private void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>(); 
        playerInput.playerControls.Keyboard.PressSpace.performed += OnPressSpace;

        GetComponent<AudioSource>().Play();

        screenManager = GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>();
        
        LockedPlayers = 0;
        deviceManager = new DeviceManager();

        for (int i = 0; i < deviceManager.gamepads.Count; i++)
        {
            GameObject menuPlayer = GetComponent<ObjectSpawner>().SpawnAtPosition(menuPlayerPrefab, Vector3.zero);
            menuPlayer.transform.SetParent(transform);
            menuPlayer.GetComponent<PlayerInput>().RestrictToDevice(deviceManager.gamepads[i]);
        }
    }

    public void OnPlayerLock(GameObject player)
    {
        MenuPlayer menuPlayer = player.GetComponent<MenuPlayer>();
        ObjectSpawner spawner = GetComponent<ObjectSpawner>();
        GameObject role = spawner.SpawnAtRandomPosition(menuPlayer.GetRolePrefab());
        role.GetComponent<PlayerColor>().color = player.GetComponent<PlayerColor>().color;
        role.GetComponent<PlayerInput>().RestrictToDevice(menuPlayer.GetComponent<PlayerInput>().device);

        if (++LockedPlayers >= deviceManager.gamepads.Count)
            AllPlayersLocked = true;
    }

    public void OnPressSpace(InputAction.CallbackContext obj)
    {
        if (AllPlayersLocked)
            screenManager.ChangeToScreen(gameplay);
    }
}
