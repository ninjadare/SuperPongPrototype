using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DariusBallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody ball;
    [SerializeField] private GameObject leftPaddle, rightPaddle;

    [SerializeField] private float ballSpeed;
    [SerializeField] private float paddleMultiplier;

    private float randomServeX;
    private float randomServeZ;


    void Start()
    {
        ball = GetComponent<Rigidbody>();

        Invoke("BallServe", 2f);
    }

    void Update()
    {

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

    public void BallReset()
    {
        // change to despawn and respawn ball
        ball.velocity = new Vector3(0, 0, 0);
        ball.transform.position = new Vector3(0f, 1f, 0f);

        Invoke("BallServe", 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == leftPaddle)
        {
            if (leftPaddle.GetComponent<Rigidbody>().velocity.x > 0)
            {
                ball.velocity = new Vector3(ballSpeed, 0f, -ballSpeed * paddleMultiplier);
            }
            else if (leftPaddle.GetComponent<Rigidbody>().velocity.x < 0)
            {
                ball.velocity = new Vector3(-ballSpeed, 0f, -ballSpeed * paddleMultiplier);
            }
            else
            {
                ball.velocity = new Vector3(0f, 0f, -ballSpeed * paddleMultiplier);
            }
        }

        if (collision.gameObject == rightPaddle)
        {
            if (rightPaddle.GetComponent<Rigidbody>().velocity.x > 0)
            {
                ball.velocity = new Vector3(ballSpeed, 0f, ballSpeed * paddleMultiplier);
            }
            else if (rightPaddle.GetComponent<Rigidbody>().velocity.x < 0)
            {
                ball.velocity = new Vector3(-ballSpeed, 0f, ballSpeed * paddleMultiplier);
            }
            else
            {
                ball.velocity = new Vector3(0f, 0f, ballSpeed * paddleMultiplier);
            }
        }
    }
}
