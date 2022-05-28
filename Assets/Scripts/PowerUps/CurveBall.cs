using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBall : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float curveTime;

    private void InitiateCurve()
    {
        ball.GetComponent<DariusBallMovement>().BallCurve();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision, ball);
        if (collision.gameObject == ball)
        {
            Invoke("InitiateCurve", curveTime);
            Debug.Log("Starting Curve");
        }
    }    
}
