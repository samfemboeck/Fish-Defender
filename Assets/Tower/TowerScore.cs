using UnityEngine;
using System.Collections;

public class TowerScore : MonoBehaviour
{
    [SerializeField]
    int score;

    [SerializeField]
    int baseScore;

    [SerializeField]
    int multiplier;

    [SerializeField]
    GameObjectSet fishes;

    [SerializeField]
    GameEvent onTowerScoreUpdate;

    //Initially calculate tower points based on fish count
    public void InitializeScore()
    {
        int fishCount = fishes.items.Count;
        score = baseScore + (fishCount * multiplier);
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
