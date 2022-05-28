using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody ballBody;

    [SerializeField] private float curveTime;
    [SerializeField] private int curveSpeed;

    public bool activateCurveBall = false;
    public bool usedCurveBall = false;

    public void BallCurve()
    {
        // called only when paddle power up is active
        if (ballBody.velocity.x > 0)
        {
            ballBody.AddForce(-curveSpeed * 2, 0, 0, ForceMode.Force);
        }
        else if (ballBody.velocity.x < 0)
        {
            ballBody.AddForce(curveSpeed * 2, 0, 0, ForceMode.Force);
        }
        else
        {
            if (ballBody.transform.position.x > 0)
            {
                ballBody.AddForce(-curveSpeed, 0, 0, ForceMode.Force);
            }
            else if (ballBody.transform.position.x < 0)
            {
                ballBody.AddForce(curveSpeed, 0, 0, ForceMode.Force);
            }
        }

        ///Debug.Log("Ending Curve");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (activateCurveBall == true)
        {
            if (usedCurveBall == false)
            {
                ///Debug.Log(collision, ball);
                if (collision.gameObject == ball)
                {
                    usedCurveBall = true;
                    Invoke("BallCurve", curveTime);
                    Debug.Log("Starting Curve");
                }
            }
        }
    }    
}
