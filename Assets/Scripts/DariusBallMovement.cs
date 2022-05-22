using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DariusBallMovement : MonoBehaviour
{
    [SerializeField] Rigidbody ball;

    [SerializeField] private float ballSpeed;

    private float randomServeX;
    private float randomServeZ;


    void Start()
    {
        ball = GetComponent<Rigidbody>();

        BallServe();
    }

    public void ResetBall()
    {
        ball.velocity = new Vector3(0, 0, 0);
        ball.transform.position = new Vector3(0f, 1f, 0f);

        Invoke("BallServe", 2f);
    }

    private void BallServe()
    {
        if (Random.value < 0.5f)
        {
            randomServeZ = 1f;
        }
        else
        {
            randomServeZ = -1f;
        }

        if (Random.value > 0.5f)
        {
            randomServeX = Random.Range(0f, 1f);
        }
        else
        {
            randomServeX = Random.Range(-1f, 0f);
        }

        ball.velocity = new Vector3(randomServeX * ballSpeed, 0f, randomServeZ * ballSpeed);
        ball.transform.position = new Vector3(0f, 1f, 0f);
    }
}
