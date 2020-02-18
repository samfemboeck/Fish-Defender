using UnityEngine.InputSystem;
using UnityEngine;

public class GameMenuState : IGameState
{
    GameManager manager;

    public GameMenuState(GameManager manager)
    {
        this.manager = manager;
    }

    public void Init()
    {
        manager.menuScreen.SetActive(true);
    }

    public void Update()
    {
        int gamepads = 0;
        
        foreach (var device in InputSystem.devices)
        {
            if (device is Gamepad)
            {
                gamepads++;
            }
        }

        manager.connectedGamepads = gamepads;

        //RM moved logic for updating UI to UiHandler
        /*
        manager.menuText = manager.menuScreen.GetComponent<Canvas>().transform.GetChild(2).gameObject.GetComponent<UnityEngine.UI.Text>();
        manager.menuText.text = gamepads + " Fishes Joined";
        */
        UiHandler.UpdateFishesJoined(gamepads);
    }

    public void OnPressSpace()
    {
        manager.isGameRunning = true;
        manager.menuScreen.SetActive(false);
        manager.activePlayers = new Player[manager.connectedGamepads];

        for (int i = 0; i < manager.activePlayers.Length; i++)
            manager.activePlayers[i] = manager.objectSpawner.SpawnPlayer().GetComponent<Player>();

        manager.scoreboard.playerScores = new int[manager.connectedGamepads];
        manager.SetGameState(manager.gameRunningState);
    }
}
