using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddleCurveBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody ballBody;

    [SerializeField] private float curveDelay;
    [SerializeField] private int curveSpeed;

    public bool activateRightCurveBall = false;
    public bool usedRightCurveBall = false;

    private void CurveBall()
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
            if (ballBody.transform.position.x >= 0)
            {
                ballBody.AddForce(-curveSpeed, 0, 0, ForceMode.Force);
            }
            else if (ballBody.transform.position.x <= 0)
            {
                ballBody.AddForce(curveSpeed, 0, 0, ForceMode.Force);
            }
        }

        ///Debug.Log("Ending Curve");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (activateRightCurveBall == true)
        {
            if (usedRightCurveBall == false)
            {
                ///Debug.Log(collision, ball);
                if (collision.gameObject == ball)
                {
                    usedRightCurveBall = true;
                    Invoke("CurveBall", curveDelay);
                    //Debug.Log("Starting Curve");
                }
            }
        }
    }    
}
