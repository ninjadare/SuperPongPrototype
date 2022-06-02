using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddleFastBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody ballBody;
    [SerializeField] private float fastDelay;
    [SerializeField] private float fastDuration;
    [SerializeField] private float fastSpeed;

    private BallMovement ballMovement;
    private float ballSpeed;

    public bool activateRightFastBall = false;
    public bool usedRightFastBall = false;

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
                usedRightFastBall = true;
            }
            else if (ballBody.transform.position.x == 0 && ballBody.velocity.z > 0)
            {
                ballBody.AddForce(0, 0, fastSpeed * 50, ForceMode.Force);
                usedRightFastBall = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (activateRightFastBall == true)
        {
            if (usedRightFastBall == false)
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
        usedRightFastBall = true;
    }
}
