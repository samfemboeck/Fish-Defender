using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class MouseTowerController : MonoBehaviour, ITowerController
{
    [SerializeField]
    private int maxMagnitude;

    private MouseControls mouseControls = new MouseControls();
    private Tower curTower;
    private Vector2 dragPosition;
    private Vector3 aimDirection;

    private void Awake()
    {
        mouseControls.OnMouseDown += MouseDown;
        mouseControls.OnMouseUp += MouseUp;
    }

	public PlayerColor PlayerColor { get => GetComponent<PlayerColor>(); }

    private void MouseUp(Vector2Control mousePos)
    {
        if (curTower)
        {
            curTower.ShootProjectile(aimDirection);
            curTower.Release();
			curTower = null;
        }
    }

    private void MouseDown(Vector2Control mousePos)
    {
        RaycastHit hit;
        Camera cam = Camera.main.GetComponent<Camera>();
        Ray ray = cam.ScreenPointToRay(mousePos.ReadValue());

        // Ignore everything BUT Projectile Layer
        if (Physics.Raycast(ray, out hit, 100f, ~LayerMask.NameToLayer("Projectile")))
        {
            Transform objectHit = hit.transform;
			Tower tower = objectHit.GetComponent<Projectile>().ActiveTower; 

			if (tower.TryClaim(this))
			{
				curTower = tower;
			}

            dragPosition = mousePos.ReadValue();
        }
    }

    private void Update()
    {
        if (curTower)
        {
            Vector2 mouseVelocity = Mouse.current.position.ReadValue() - dragPosition;
            // keep mouseDelta between 0 and 1. Let Tower decide what the actual velocity should be.
            Vector2 mouseDelta = -(Vector3.ClampMagnitude(mouseVelocity, maxMagnitude) / maxMagnitude);
            aimDirection = new Vector3(mouseDelta.x, 0, mouseDelta.y);
            curTower.SetAimDirection(aimDirection);
        }
    }

    private void FixedUpdate()
    {
        mouseControls.FixedUpdate();
    }
}
