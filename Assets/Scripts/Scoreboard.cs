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

    public void OnCollect(int id)
    {
        towerScore -= 1;
        playerScores[id] += 1;

        if (towerScore <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // TODO End Screen
        }
    }
}
