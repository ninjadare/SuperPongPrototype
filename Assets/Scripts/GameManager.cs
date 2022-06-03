using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Written by Zane/Darius
public class GameManager : MonoBehaviour
{
    [SerializeField] private  GameObject mainMenu;
    [SerializeField] private  GameObject controlsMenu;
    [SerializeField] private GameObject leftPlayerWinScreen;
    [SerializeField] private GameObject rightPlayerWinScreen;
    [SerializeField] private GameObject Ball;
    [SerializeField] private Text leftScoreText;
    [SerializeField] private Text rightScoreText;
    [SerializeField] private float matchPoint;

    private bool gameOver = false;

    public int leftPlayerScore;
    public int rightPlayerScore;

    private void Start()
    {
        Time.timeScale = 0;
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

        if(Input.GetKey(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
    }

    public void ControlsMenu()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public static void QuitGame()
    {
        Application.Quit();
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
        leftPlayerWinScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    private void RightPlayerWins()
    {
        rightPlayerWinScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
