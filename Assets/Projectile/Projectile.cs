using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 5)]
    public float destroyDelay;

    [SerializeField]
    GameEvent onPlayerKill;

    public Tower ActiveTower { get; set; }

    public void Shoot(Vector3 velocity)
    {
        GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
        Destroy(gameObject, destroyDelay);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            onPlayerKill.Raise(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
