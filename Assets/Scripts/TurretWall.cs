using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWall : MonoBehaviour
{
    Ball ball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            ball = other.gameObject.GetComponent<Ball>();
        }
        
        if (other.gameObject.CompareTag("Ball") && ball != null && ball.hasLeftTurretWall)
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ball.hasLeftTurretWall = true;
    }


}
