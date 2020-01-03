using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    public int speed = 1000;
    public int minSpeed = 100;
    public bool hasLeftTurretWall = false;
    public Turret turret;
    private bool isDragged;
    private bool wasShot;
    private Rigidbody rigidbody;
    private LineRenderer lineRenderer;
    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.FindGameObjectWithTag("Turret").GetComponent<Turret>();
        rigidbody = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        collider = GetComponent<Collider>();
        wasShot = false;
    }

    // TODO kinda buggy -> probably needs Raycast
    void FixedUpdate()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && collider.bounds.Contains(GetMousePosWorld()))
        {
            isDragged = true;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame && isDragged)
        {
            wasShot = true;
            isDragged = false;        
            Vector3 direction = (transform.position - GetMousePosWorld());
            Vector3 force = (direction.magnitude * speed) < minSpeed ? minSpeed * direction.normalized : speed * direction;
            rigidbody.AddForce(force);
            turret.ScheduleBall();
            lineRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragged)
        {
            lineRenderer.SetPosition(0, transform.position);
            Vector3 offset = transform.position - GetMousePosWorld();
            lineRenderer.SetPosition(1, transform.position + offset);
        } 

        if (wasShot && rigidbody.velocity.magnitude <= 0.5)
        {
            Destroy(gameObject);
        }
    }

    Vector3 GetMousePosWorld()
    {
        Vector2 mousePosCamera = Mouse.current.position.ReadValue();
        Vector3 mousePointWorld =  Camera.main.ScreenToWorldPoint(new Vector3(mousePosCamera.x, mousePosCamera.y, Camera.main.transform.position.y));
        mousePointWorld.y = transform.position.y;
        return mousePointWorld;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
