using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Collider collider;
    public Ball ball;
    bool isBallScheduled = false;
    public const float spawnTimeout = 1;
    float timer;

    void Start()
    {
        collider = GetComponent<Collider>();
        SpawnBall();
    }

    void Update()
    {
        if (isBallScheduled)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                SpawnBall();
                isBallScheduled = false;
            }
        }
    }

    void SpawnBall()
    {
        float ballRadius = ball.GetComponent<Renderer>().bounds.extents.y;
        float turretRadius = GetComponent<Collider>().bounds.extents.y;
        Vector3 pos = GetComponent<Transform>().position;
        Vector3 ballPos = new Vector3(pos.x, pos.y + turretRadius + ballRadius, pos.z);
        Ball b = Instantiate(ball, ballPos, Quaternion.identity);
        b.turret = this;
    }

    public void ScheduleBall(float seconds = spawnTimeout)
    {
        isBallScheduled = true;
        timer = seconds;
    }
}
