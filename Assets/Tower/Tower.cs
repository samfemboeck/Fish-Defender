using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnDelay;
    public float ballOffset;
    public Vector2 direction;
    public GameObject ActiveProjectile { get; private set; }

    void Start()
    {
        SpawnProjectile();
    }
 
    void SpawnProjectile()
    {
        if (ActiveProjectile)
            return;
            
        float projectileRadius = projectilePrefab.GetComponent<Renderer>().bounds.extents.y;
        float turretRadius = GetComponent<Renderer>().bounds.extents.y;
        Vector3 center = GetComponent<Renderer>().bounds.center;
        Vector3 projectilePos = new Vector3(center.x, center.y + ballOffset, center.z);
        ActiveProjectile = Instantiate(projectilePrefab, projectilePos, Quaternion.identity);
    }

    void ShootProjectile(Vector3 direction)
    {
        if (!ActiveProjectile)
            return;

        Projectile projectile = ActiveProjectile.GetComponent<Projectile>();
        projectile.Shoot(direction);
        ActiveProjectile = null;
        Invoke("SpawnProjectile", spawnDelay);
    }
}
