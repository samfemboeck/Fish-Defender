using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    GameEvent onCollect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            onCollect.Raise(other.gameObject);
            Destroy(gameObject);
        }
    }
}
