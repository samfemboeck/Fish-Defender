using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    GameEvent onFishCollect;

    AudioManager audio;

    private void Awake()
    {
        audio = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            FishScore score = other.gameObject.GetComponent<FishScore>();
            score.Score += 1;
            onFishCollect.Raise(other.gameObject);
            Destroy(gameObject);

            audio.Play("CollectibleCollect");
        }
    }
}
