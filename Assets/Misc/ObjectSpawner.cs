using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;
    public GameObject playerPrefab;
    public GameObject towerPlayerPrefab;
    public GameObject fishPlayerPrefab;
    public float spawnTime;
    public static bool isActive = false;
    private float timer;

    void Start()
    {
        timer = spawnTime;
    }

    public void SpawnCollectible()
    {
        Instantiate(collectiblePrefab, GetRandomSpawnPosition(), Quaternion.identity);
    }

    public GameObject SpawnPlayer()
    {
        return Instantiate(playerPrefab, GetRandomSpawnPosition(), Quaternion.identity);
    }

    Vector3 GetRandomMapPosition()
    { 
        float randX = Random.Range(-7, 7);
        float randZ = Random.Range(-6, 6);
        return new Vector3(randX, 1.264f, randZ);
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPos;
        bool error = true;
        do
        {
            spawnPos = GetRandomMapPosition();
            Vector3 rayDirection = spawnPos - Camera.main.transform.position;
            RaycastHit hit;
            Physics.Raycast(Camera.main.transform.position, rayDirection, out hit);

            // Obstacle was hit
            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                error = false;
            }
        } while (error);
        return spawnPos;
    }

    private void Update()
    {
        if (!isActive)
            return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = spawnTime;
            if (Collectible.instances < 5)
                SpawnCollectible();
        }
    }
}
