using UnityEngine;

public class FishScore : MonoBehaviour
{
    [SerializeField]
    GameEvent onFishScoreUpdate;

    public int Score { get; set; }

    public void OnFishCollect(GameObject gameObject)
    {
        if (this.gameObject == gameObject)
        {
            Score += 1;
            onFishScoreUpdate.Raise(gameObject);
        }
    }
}
