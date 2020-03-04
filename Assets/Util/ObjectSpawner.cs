using UnityEngine;
using System.Collections;

/*
 * Utility script for spawning objects.
 */
public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    Map map;

    public GameObject SpawnAtRandomPosition(GameObject prefab)
    {
        return Instantiate(prefab, GetRandomSpawnPosition(), Quaternion.identity);
    }

    public GameObject SpawnAndSetY(GameObject prefab, Vector3 position)
    {
        return SpawnAtPosition(prefab, position.With(y: map.yCoordinate));
    }

    public GameObject SpawnAtPosition(GameObject prefab, Vector3 position)
    {
        return Instantiate(prefab, position, Quaternion.identity);
    }
    
    Vector3 GetRandomMapPosition()
    { 
        // TODO magic numbers
        float randX = Random.Range(-7, 7);
        float randZ = Random.Range(-6, 6);
        return new Vector3(randX, map.yCoordinate, randZ);
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

}
