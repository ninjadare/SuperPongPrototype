using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Ball;
    public int leftScore;
    public int rightScore;

    // Start is called before the first frame update
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
    }

    public void UpdateLeftScore()
    {
        leftScore++;
        Debug.Log(leftScore);
        Ball.GetComponent<DariusBallMovement>().BallReset();
        //Ball.GetComponent<BallMovement>().BallReset();
    }

    public void UpdateRightScore()
    {
        rightScore++;
        Debug.Log(rightScore);
        Ball.GetComponent<DariusBallMovement>().BallReset();
        //Ball.GetComponent<BallMovement>().BallReset();
    }
}
