using UnityEngine;

public class Tower : MonoBehaviour
{
    public int index;

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    [Range(0, 10)]
    private float aimIndicatorRange;

    [SerializeField]
    [Range(0, 100)]
    private float projectileSpeed;

    [SerializeField]
    [Range(0, 5)]
    private float projectileSpawnDelay;

    public Projectile ActiveProjectile { get; private set; }
    public GamepadTowerController ActivePlayer { get; set; }
 
    public void SpawnProjectile()
    {
        if (ActiveProjectile)
            return;
            
        Vector3 center = GetComponent<Renderer>().bounds.center;
        ActiveProjectile = GetComponent<ObjectSpawner>().SpawnAndSetY(projectilePrefab, center).GetComponent<Projectile>();
        ActiveProjectile.ActiveTower = this;
    }

    // direction is a vector with magnitude between 0 and 1!
    public void SetAimDirection(Vector3 direction)
    {
        if (!ActiveProjectile)
            return;

        Vector3 projectilePos = ActiveProjectile.transform.position;
        ActiveProjectile.GetComponent<LineRenderer>().SetPosition(0, projectilePos);
        ActiveProjectile.GetComponent<LineRenderer>().SetPosition(1, projectilePos + (direction * aimIndicatorRange));
    }

    public void ShootProjectile(Vector3 direction)
    {
        if (!ActiveProjectile)
            return;

        ActiveProjectile.Shoot(direction * projectileSpeed);
        ActiveProjectile = null;
        Invoke("SpawnProjectile", projectileSpawnDelay);
    }

    public bool TryClaim(GamepadTowerController gamepadTowerController)
    {
        if (ActivePlayer)
            return false;

        ActivePlayer = gamepadTowerController;
        return true;
    }
}
