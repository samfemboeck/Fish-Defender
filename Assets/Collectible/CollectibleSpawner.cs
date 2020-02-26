using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject collectiblePrefab;

    [SerializeField]
    GameObjectSet collectibles;

    [SerializeField]
    float spawnTime;

    private void Start()
    {
        Enable();
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
            GetComponent<ObjectSpawner>().SpawnAtRandomPosition(collectiblePrefab);
    }
}
