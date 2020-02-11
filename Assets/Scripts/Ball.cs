using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    public int speed = 1000;
    public int minSpeed = 100;
    public float timer = 1;
    public bool hasLeftTurretWall = false;
    public Turret turret;
    private bool isDragged;
    private bool wasShot;
    private Rigidbody rigidbody;
    private LineRenderer lineRenderer;
    private Collider collider;
    private InputAction clickAction;

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.FindGameObjectWithTag("Turret").GetComponent<Turret>();
        rigidbody = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        collider = GetComponent<Collider>();
        wasShot = false;
        clickAction = new InputAction(binding: "<Mouse>/leftButton");
        clickAction.Enable();
        clickAction.performed += ctx => OnMouseDown(ctx);
        clickAction.canceled += ctx => OnMouseUp(ctx);
    }

    void OnMouseDown(InputAction.CallbackContext ctx) 
    {
        Vector3 rayDirection = GetMousePosWorld() - Camera.main.transform.position;
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, rayDirection, out hit);

        if (hit.collider.gameObject.CompareTag("Ball"))
        {
            isDragged = true;
        }
    }

    private void OnMouseUp(InputAction.CallbackContext ctx)
    {
        if (isDragged)
        {
            isDragged = false;
            Vector3 direction = (transform.position - GetMousePosWorld(true));
            Vector3 force = (direction.magnitude * speed) < minSpeed ? minSpeed * direction.normalized : speed * direction;
            rigidbody.AddForce(force, ForceMode.Impulse);
            turret.ScheduleBall();
            lineRenderer.enabled = false;
            wasShot = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragged)
        {
            lineRenderer.SetPosition(0, transform.position);
            Vector3 offset = transform.position - GetMousePosWorld(true);
            lineRenderer.SetPosition(1, transform.position + offset);
        }

        if (wasShot)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    Vector3 GetMousePosWorld(bool leveled = false)
    {
        Vector2 mousePosCamera = Mouse.current.position.ReadValue();
        Vector3 mousePointWorld =  Camera.main.ScreenToWorldPoint(new Vector3(mousePosCamera.x, mousePosCamera.y, Camera.main.transform.position.y));
        if (leveled)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
