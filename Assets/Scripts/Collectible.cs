using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private ObjectSpawner objectSpawner;

    // Start is called before the first frame update
    void Start()
    {
        objectSpawner = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<ObjectSpawner>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player.CompareTag("Player"))
        {
            Destroy(gameObject);
            objectSpawner.SpawnCollectible();
            player.OnCollect();
        }
    }
}
