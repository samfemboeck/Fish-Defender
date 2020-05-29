using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    GameEvent onFishCollect;

    AudioManager audio;
    string[] collectSounds =
    {
        "CollectibleCollect1",
        "CollectibleCollect2",
        "CollectibleCollect3",
        "CollectibleCollect4",
    };

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
            GetComponent<GameObjectItem>().set.Remove(gameObject);

            int soundIndex = Random.Range(0, collectSounds.Length);
            audio.Play(collectSounds[soundIndex]);
        }
    }
}
