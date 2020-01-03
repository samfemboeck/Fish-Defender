using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.FindGameObjectWithTag("Turret").GetComponent<Turret>();
        rigidbody = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        wasShot = false;
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
        if (wasShot && rigidbody.velocity.magnitude <= 0.1)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    { 
        isDragged = true;
    }

    private void OnMouseUp()
    {
        wasShot = true;
        isDragged = false;        
        Vector3 direction = (transform.position - GetMousePosWorld());
        Vector3 force = (direction.magnitude * speed) < minSpeed ? minSpeed * direction.normalized : speed * direction;
        rigidbody.AddForce(force);
        turret.ScheduleBall();
    }

    Vector3 GetMousePosWorld()
    {
        Vector3 mousePointWorld =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
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
