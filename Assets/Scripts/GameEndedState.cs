using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndedState : IGameState 
{
    private GameManager manager;

    public GameEndedState(GameManager manager)
    {
        this.manager = manager;
    }

    public void Init()
    {
        Debug.Log("ending game.");
        foreach (Player p in manager.activePlayers)
        {
            if (p != null)
                Object.Destroy(p.gameObject);
        }
    }

    public void OnPressSpace()
    {
        manager.SetGameState(manager.gameMenuState);
    }

    public void Update(){}
}
