using UnityEngine;

public class FishScore : MonoBehaviour
{
    [SerializeField]
    GameEvent onFishScoreUpdate;

    public int Score { get; set; }


    // Use this for initialization
    public void OnFishCollect(GameObject gameObject)
    {
        if (this.gameObject == gameObject)
        {
            Score += 1;
            onFishScoreUpdate.Raise(gameObject);
        }
    }
}
