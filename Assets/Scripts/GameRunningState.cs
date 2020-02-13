using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunningState : IGameState 
{
    private GameManager manager;

    public GameRunningState(GameManager manager)
    {
        this.manager = manager;
    }

    public void Init()
    {
        Debug.Log("starting game.");
        ObjectSpawner.isActive = true;
    }

    public void OnPressSpace()
    {
        // Pause game
    }

    public void Update()
    {
        if (Player.instances <= 0 || Scoreboard.towerHealth <= 0)
        {
            manager.isGameRunning = false;
            manager.SetGameState(manager.gameEndedState);
        }
    }
}
