using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int speed = 1000;
    public int minSpeed = 100;
    public float destroyDelay;

    public void Shoot(Vector3 direction)
    {
        Vector3 force = (direction.magnitude * speed) < minSpeed ? minSpeed * direction.normalized : speed * direction;
        print(force);
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        Destroy(gameObject, destroyDelay);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
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
