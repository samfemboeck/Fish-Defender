using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounce = 20;
    public float cooldown = 1f;
    private float curCooldown = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (curCooldown > 0)
        {
            curCooldown -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "player" && curCooldown <= 0)
        {
            Vector2 playerPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
            Vector3 collisionPoint = collision.GetContact(0).point;
            Vector2 collisionPoint2D = new Vector2(collisionPoint.x, collisionPoint.z);
            Vector3 dir = new Vector3(playerPos.x - collisionPoint2D.x, 0, playerPos.y - collisionPoint2D.y);
            rb.AddForce(dir.normalized * bounce, ForceMode.VelocityChange); // TODO Error Message 
            curCooldown = cooldown;
        }
    }
}
