using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    [Range(0, 100)]
    float projectileSpeed;

    [SerializeField]
    [Range(0, 5)]
    public float projectileSpawnDelay;

    public GameObject ActiveProjectile { get; private set; }

    void Start()
    {
        SpawnProjectile();
    }
 
    void SpawnProjectile()
    {
        if (ActiveProjectile)
            return;
            
        Vector3 center = GetComponent<Renderer>().bounds.center;
        ActiveProjectile = GetComponent<ObjectSpawner>().SpawnAndSetY(projectilePrefab, center);
    }

    public void ShootProjectile(Vector3 direction)
    {
        if (!ActiveProjectile)
            return;

        ActiveProjectile.GetComponent<Projectile>().Shoot(direction * projectileSpeed);
        ActiveProjectile = null;
        Invoke("SpawnProjectile", projectileSpawnDelay);
    }
}
