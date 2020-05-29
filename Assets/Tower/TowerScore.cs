using UnityEngine;
using System.Collections;

public class TowerScore : MonoBehaviour
{
    [SerializeField]
    static int baseScore = 6;

    [SerializeField]
    static int multiplier = 2;

    [SerializeField]
    static int score = 0;

    [SerializeField]
    GameObjectSet fishes;

    [SerializeField]
    GameObjectSet towers;

    [SerializeField]
    GameEvent onTowerScoreUpdate;

    public int Score { get => score; private set => score = value; }

    //Initially calculate tower points based on fish count
    public void InitializeScore()
    {
        int fishCount = fishes.items.Count;
        score = baseScore + (fishCount * multiplier);
    }

    public void OnFishCollect(GameEvent gameEvent)
    {
        Score -= 1;
        onTowerScoreUpdate.Raise(gameObject);
    }
}
