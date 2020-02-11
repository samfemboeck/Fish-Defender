using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviour
{
    public int towerScore = 10;
    IDictionary<int, int> playerScores = new Dictionary<int, int>();
    private GameManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    public void addPlayer(int id)
    {
        if (!playerScores.ContainsKey(id))
            playerScores.Add(id, 0);
    }

    public void OnPlayerCollect(int id)
    {
        towerScore -= 1;
        playerScores[id] += 1;

    }

    public void OnPlayerKill(int id)
    {
        playerScores.Remove(id);
    }

    private void Update()
    {
        if (manager.isGameRunning)
        {
            if (Player.INSTANCES <= 0)
            {
                // Tower has ID 0
                manager.EndGame(0);
            }

            if (towerScore <= 0)
            {
                int winner = 0;
                foreach (KeyValuePair<int, int> entry in playerScores)
                {
                    if (entry.Value > winner)
                        winner = entry.Key;
                }
                // fish IDs start at value 1
                manager.EndGame(winner);
            }
        }
    }
}
