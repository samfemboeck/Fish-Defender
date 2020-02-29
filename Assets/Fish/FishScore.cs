using UnityEngine;

public class FishScore : MonoBehaviour
{
    [SerializeField]
    GameEvent onFishScoreUpdate;

    int score;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            onFishScoreUpdate.Raise(gameObject);
        }
    }
}
