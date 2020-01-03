using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    static int INSTANCES = 0;
    private int ID;
    public float maxSpeed = 2000;
    public float forwardSpeed = 40;
    public float rotateSpeed = 40;
    public float maxRotationSpeed = 3;
    public float minSpeed = 0.5f;
    private Scoreboard scoreboard;
    public Rigidbody rb;
    private Vector2 leftStick;
    private ObjectSpawner objectSpawner;

    // Start is called before the first frame update
    void Start()
    {
        ID = INSTANCES++;
        scoreboard = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<Scoreboard>();
        scoreboard.addPlayer(ID);
        rb = gameObject.GetComponent<Rigidbody>();
        objectSpawner = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<ObjectSpawner>();
    }

    public void OnClickButtonSouth(InputValue value)
    {
        rb.AddForce(transform.forward * forwardSpeed);
    }

    public void OnMoveLeftStick(InputValue value)
    {
        leftStick = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        //Rotation
        if (rb.velocity.magnitude > 0)
        {
            Vector3 addRotation = new Vector3(0, rotateSpeed * leftStick.x * (rb.velocity.magnitude / maxSpeed), 0);
            Vector3 currentTorque = rb.angularVelocity;
            if (currentTorque.magnitude > maxRotationSpeed)
            {
                rb.angularVelocity = currentTorque.normalized * maxRotationSpeed;
            }
            else
            {
                rb.AddTorque(addRotation);
            }
        }

        if (rb.velocity.magnitude < 0.5f)
        {
            rb.angularVelocity = Vector3.zero;
        }

        rb.velocity = transform.forward * rb.velocity.magnitude;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            objectSpawner.SpawnCollectible();
            scoreboard.OnCollect(this.ID);
        }
    }

    public void OnCollect()
    {
        scoreboard.OnCollect(ID);
    }
}
