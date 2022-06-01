using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleFastBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody ballBody;
    [SerializeField] private float fastDelay;
    [SerializeField] private float fastDuration;
    [SerializeField] private float fastSpeed;

    private BallMovement ballMovement;
    private float ballSpeed;

    public bool activateLeftFastBall = false;
    public bool usedLeftFastBall = false;

    private void Start()
    {
        ballMovement = ball.GetComponent<BallMovement>();
        ballSpeed = ballMovement.ballSpeed;
    }

    private void FastBall()
    {
        if (ballBody.velocity.x != 0)
        {
            ballMovement.ballSpeed = fastSpeed;
            StartCoroutine(FastBallDuration(fastDuration));
        }
        else
        {
            if (ballBody.transform.position.x == 0 && ballBody.velocity.z < 0)
            {
                ballBody.AddForce(0, 0, -fastSpeed * 50, ForceMode.Force);
                usedLeftFastBall = true;
            }
            else if (ballBody.transform.position.x == 0 && ballBody.velocity.z > 0)
            {
                ballBody.AddForce(0, 0, fastSpeed * 50, ForceMode.Force);
                usedLeftFastBall = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (activateLeftFastBall == true)
        {
            if (usedLeftFastBall == false)
            {
                if (collision.gameObject == ball)
                {
                    Invoke("FastBall", fastDelay);
                }
            }
        }
    }

    IEnumerator FastBallDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        ballMovement.ballSpeed = ballSpeed;
        usedLeftFastBall = true;
    }
}
