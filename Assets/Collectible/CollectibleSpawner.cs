using UnityEngine;

[RequireComponent(typeof(ObjectSpawner))]
public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject collectiblePrefab;

    [SerializeField]
    GameObjectSet collectibles;

    [SerializeField]
    float spawnTime;

    AudioManager audio;
    string[] spawnSounds =
    {
        "CollectibleSpawn1",
        "CollectibleSpawn2",
        "CollectibleSpawn3",
        "CollectibleSpawn4",
        "CollectibleSpawn5"
    };

    private void Start()
    {
        Enable();
        audio = FindObjectOfType<AudioManager>();
    }

    public void Enable()
    {
        CancelInvoke("TrySpawnCollectible");
        InvokeRepeating("TrySpawnCollectible", spawnTime, spawnTime);
    }

    public void Disable()
    {
        CancelInvoke("TrySpawnCollectible");
    }

    public void TrySpawnCollectible()
    {
        if (collectibles.Count < 5)
        {
            GetComponent<ObjectSpawner>().SpawnAtRandomPosition(collectiblePrefab);

            int soundIndex = Random.Range(0, spawnSounds.Length);
            audio.Play(spawnSounds[soundIndex]);
        }
    }
}
