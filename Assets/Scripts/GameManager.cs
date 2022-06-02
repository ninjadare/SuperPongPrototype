using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Ball;
    [SerializeField] private Text leftScoreText;
    [SerializeField] private Text rightScoreText;
    [SerializeField] private float matchPoint;

    private bool gameOver = false;

    public int leftPlayerScore;
    public int rightPlayerScore;

    // Start is called before the first frame update
    private void Start()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
    }

    private void Update()
    {
        if (leftPlayerScore == matchPoint && gameOver == false)
        {
            LeftPlayerWins();
            gameOver = true;
        }
        else if (rightPlayerScore == matchPoint && gameOver == false)
        {
            RightPlayerWins();
            gameOver = true;
        }
    }

    public void UpdateLeftPlayerScore()
    {
        leftPlayerScore++;

        if (leftPlayerScore >= 10 && leftPlayerScore == rightPlayerScore)
        {
            matchPoint++;
        }

        if (leftPlayerScore < 10)
        {
            leftScoreText.text = "0" + leftPlayerScore.ToString();
        }
        else
        {
            leftScoreText.text = leftPlayerScore.ToString();
        }

        Ball.GetComponent<BallMovement>().BallReset();
    }

    public void UpdateRightPlayerScore()
    {
        rightPlayerScore++;

        if (rightPlayerScore >= 10 && leftPlayerScore == rightPlayerScore)
        {
            matchPoint++;
        }

        if (rightPlayerScore < 10)
        {
            rightScoreText.text = "0" + rightPlayerScore.ToString();
        }
        else
        {
            rightScoreText.text = rightPlayerScore.ToString();
        }

        Ball.GetComponent<BallMovement>().BallReset();
    }

    private void LeftPlayerWins()
    {
        Debug.Log("Left Player Wins!");
        Time.timeScale = 0f;
    }

    private void RightPlayerWins()
    {
        Debug.Log("Right Player Wins!");
        Time.timeScale = 0f;
    }
}
