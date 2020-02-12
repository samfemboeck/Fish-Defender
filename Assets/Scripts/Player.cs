using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static int INSTANCES = 0;
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

    private Vector3 impulseDirection;
    public float negSpeed = -0.1f;
    public float friction = 10;

    // Start is called before the first frame update
    void Start()
    {
        ID = ++INSTANCES;
        scoreboard = GameObject.FindGameObjectWithTag("Scoreboard").GetComponent<Scoreboard>();
        scoreboard.addPlayer(ID);
        rb = gameObject.GetComponent<Rigidbody>();
        objectSpawner = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<ObjectSpawner>();
    }

    public void OnClickButtonSouth(InputValue value)
    {
        //Debug.Log("forward "+fire);

        //Update impulse dir for friction
        impulseDirection = transform.forward;

        Vector3 dir = transform.forward;

        if (rb.velocity.magnitude > maxSpeed)
        {
            //rb.velocity = transform.forward * maxSpeed;
        }
        else
        {
            rb.AddForce(dir * forwardSpeed);
        }
    }

    public void OnMoveLeftStick(InputValue value)
    {
        leftStick = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        //Rotation
        if (rb.velocity.magnitude > 0)
        {
            /*
            Vector3 addRotation = new Vector3(0, rotateSpeed * leftStick.x * (rb.velocity.magnitude/maxSpeed), 0);
            Quaternion deltaRotation = Quaternion.Euler(addRotation * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);

            //Update force direction
            rb.velocity = transform.forward * rb.velocity.magnitude;
            */

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

        if (rb.velocity.magnitude < 0.5)
        {
            rb.angularVelocity = Vector3.zero;
        }

        rb.velocity = transform.forward * rb.velocity.magnitude;


        //RoateFriction
        /*
        if (rb.angularVelocity.magnitude > 0)
        {
            Vector3 dir = rb.angularVelocity.normalized;
            rb.AddForce(dir * -rotateFriction * Time.deltaTime);
            if (rb.angularVelocity.magnitude - rotateFriction * Time.deltaTime < 0)
            {
                rb.velocity = Vector3.zero;
            }
            else
            {
                rb.AddForce(dir * -rotateFriction * Time.deltaTime);
            }
        }
        */

        //Friction
        if (rb.velocity.magnitude > 0)
        {
            //Debug.Log("friction active");
            Vector3 dir = transform.forward;
            rb.AddForce(dir * -friction * Time.deltaTime);
            if (rb.velocity.magnitude - friction * Time.deltaTime < 0)
            {
                rb.velocity = dir * negSpeed;
            }
            else
            {
                rb.AddForce(dir * -friction * Time.deltaTime);
            }
        }
        /*
        if(rb.velocity.magnitude<=0.5)
        {
            Debug.Log("angual Velocity adjusted because no movement");
            rb.angularVelocity = Vector3.zero;
        }*/

    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            objectSpawner.SpawnCollectible();
            scoreboard.OnPlayerCollect(this.ID);
        }
    }

    private void OnDestroy()
    {
        INSTANCES--;
    }
}
