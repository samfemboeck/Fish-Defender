using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 5)]
    public float destroyDelay;

    [SerializeField]
    GameEvent onPlayerKill;

    public Tower ActiveTower { get; set; }

    AudioManager audio;

    private void Awake()
    {
        audio = FindObjectOfType<AudioManager>();
    }

    public void Shoot(Vector3 velocity)
    {
        GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);
        Destroy(gameObject, destroyDelay);

        audio.Play("Schuss");
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            onPlayerKill.Raise(other.gameObject);
            Destroy(gameObject);
            Destroy(other.gameObject);

            audio.Play("FishDie");
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
