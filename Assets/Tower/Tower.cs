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

	[SerializeField]
	private Color neutralColor;

    public Projectile ActiveProjectile { get; private set; }
    public ITowerController ActiveController { get; set; }
 
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

    public bool TryClaim(ITowerController towerController)
    {
        if (ActiveController != null)
            return false;

        ActiveController = towerController;
		SetColor(ActiveController.PlayerColor.color);
        return true;
    }

	private Color GetDarkerShadeFor(Color color)
	{
		float hue, saturation, val;
		Color.RGBToHSV(color, out hue, out saturation, out val);
		val *= 0.5f;
		return Color.HSVToRGB(hue, saturation, val);
	}

	public void Release()
	{
		ActiveController = null;
		SetColor(neutralColor);
	}

	private void SetColor(Color color)
	{
		gameObject.GetComponent<Renderer>().material.SetColor("_ColorMin", GetDarkerShadeFor(color));
		gameObject.GetComponent<Renderer>().material.SetColor("_ColorMax", color);
		Light light = GetComponentInChildren<Light>();
		light.color = color;
	}

    public void UnLoad()
    {
        if (ActiveProjectile)
        {
            Destroy(ActiveProjectile.gameObject);
            ActiveProjectile = null;
        }
        CancelInvoke();
    }
}
