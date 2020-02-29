using UnityEngine;
using System.Collections;

public class TowerScore : MonoBehaviour
{
    [SerializeField]
    int score;

    [SerializeField]
    GameEvent onTowerScoreUpdate;

    public int Score 
    {
        get { return score; }
        private set { score = value; } 
    }

    public void OnFishCollect(GameObject fish)
    {
        Score -= 1;
        onTowerScoreUpdate.Raise(gameObject);
    }
}
