using System;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    [Range(0, 1000)]
    public float rotateSpeed;
    [Range(0, 5000)]
    public float maxSpeed;
    [Range(0, 10)]
    public float maxRotationSpeed;
    [Range(0, 100)]
    public float friction;
    [Range(-1, 0)]
    public float negativeSpeed;
    [Range(0, 100)]
    public float forwardSpeed;

    Vector2 rotation;

    public void PushForward()
    {
        Vector3 dir = transform.forward;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (!(rb.velocity.magnitude > maxSpeed))
            rb.AddForce(dir * forwardSpeed);
    }


    public void SetRotation(Vector2 rot)
    {
        rotation = rot;
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Rotation
        Vector3 addRotation = new Vector3(0, rotateSpeed * rotation.x * (Math.Max(rb.velocity.magnitude, 1) / maxSpeed), 0);
        Vector3 currentTorque = rb.angularVelocity;
        if (currentTorque.magnitude > maxRotationSpeed)
        {
            rb.angularVelocity = currentTorque.normalized * maxRotationSpeed;
        }
        else
        {
            rb.AddTorque(addRotation);
        }

        rb.velocity = transform.forward * rb.velocity.magnitude;


        // Friction
        if (rb.velocity.magnitude > 1)
        {
            Vector3 dir = transform.forward;
            rb.AddForce(dir * -friction * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rotation *= 2;
    }
}
