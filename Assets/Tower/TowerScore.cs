using UnityEngine;
using System.Collections;

public class TowerScore : MonoBehaviour
{
    [SerializeField]
    int score = 3;

    [SerializeField]
    static int baseScore = 6;

    [SerializeField]
    static int multiplier = 2;

    [SerializeField]
    GameObjectSet fishes;

    [SerializeField]
    GameObjectSet towers;

    [SerializeField]
    GameEvent onTowerScoreUpdate;

    //Initially calculate tower points based on fish count
    public void InitializeScore()
    {
        int fishCount = fishes.items.Count;
        score = baseScore + (fishCount * multiplier);
        print("debug tower score: " + score + " " + fishCount);
    }

    public int Score 
    {
        get { return score; }
        private set { score = value; } 
    }

    public void OnFishCollect(GameEvent gameEvent)
    {
        Score -= 1;
        onTowerScoreUpdate.Raise(gameObject);
    }
}
