using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddlePowerUps : MonoBehaviour
{
    [Header("Fast Ball Power-Up")]
    [SerializeField] private KeyCode fastBallKey;
    [SerializeField] private float fastBallCooldownTime;
    [SerializeField] private LeftPaddleFastBall fastBallScript;

    [Header("Curve Ball Power-Up")]
    [SerializeField] private KeyCode curveBallKey;
    [SerializeField] private float curveBallCooldownTime;
    [SerializeField] private LeftPaddleCurveBall curveBallScript;

    [Header("Paddle Grow Power-Up")]
    [SerializeField] private KeyCode paddleGrowKey;
    [SerializeField] private float paddleGrowCooldownTime;
    [SerializeField] private LeftPaddleGrow growPaddleScript;

    [Header("Paddle Accelerate Power-Up")]
    [SerializeField] private KeyCode paddleAccelerateKey;
    [SerializeField] private float paddleAccelerateCooldownTime;
    [SerializeField] private LeftPaddleAccelerate acceleratePaddleScript;

    private MeshRenderer material;

    private bool powerupActive = false;
    private bool deactivateFastBall;
    private bool deactivateCurveBall;
    private bool deactivatePaddleGrow;
    private bool deactivatePaddleAccelerate;

    private void Start()
    {
        material = this.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        ActivateCurveBall();
        ActivatePaddleGrow();
        ActivateFastBall();
        ActivatePaddleAccelerate();
    }

    private void ActivateFastBall()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(fastBallKey) && deactivateFastBall == false)
            {
                fastBallScript.activateLeftFastBall = true;
                deactivateFastBall = true;
                Debug.Log("LEFT PADDLE FAST BALL ACTIVATED");
                powerupActive = true;
            }
        }

        if (fastBallScript.usedLeftFastBall == true)
        {
            fastBallScript.usedLeftFastBall = false;
            fastBallScript.activateLeftFastBall = false;
            Debug.Log("LEFT PADDLE FAST BALL DEACTIVATED");
            powerupActive = false;
            StartCoroutine(FastBallCooldown());
        }
    }

    IEnumerator FastBallCooldown()
    {
        yield return new WaitForSeconds(fastBallCooldownTime);
        deactivateFastBall = false;
        Debug.Log("LEFT PADDLE FAST BALL READY");
    }

    private void ActivateCurveBall()
    {
        if(powerupActive == false)
        {
            if (Input.GetKeyDown(curveBallKey) && deactivateCurveBall == false)
            {
                curveBallScript.activateLeftCurveBall = true;
                deactivateCurveBall = true;
                Debug.Log("LEFT PADDLE CURVE BALL ACTIVATED");
            }
        }

        if (curveBallScript.usedLeftCurveBall == true)
        {
            curveBallScript.usedLeftCurveBall = false;
            curveBallScript.activateLeftCurveBall = false;
            Debug.Log("LEFT PADDLE CURVE BALL DEACTIVATED");
            StartCoroutine(CurveBallCooldown());
        }
    }

    IEnumerator CurveBallCooldown()
    {
        yield return new WaitForSeconds(curveBallCooldownTime);
        deactivateCurveBall = false;
        Debug.Log("LEFT PADDLE CURVE BALL READY");
    }

    private void ActivatePaddleGrow()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(paddleGrowKey) && deactivatePaddleGrow == false)
            {
                growPaddleScript.activateLeftPaddleGrow = true;
                deactivatePaddleGrow = true;
                Debug.Log("LEFT PADDLE GROW ACTIVATED");
            }
        }

        if (growPaddleScript.usedLeftPaddleGrow == true)
        {
            growPaddleScript.usedLeftPaddleGrow = false;
            Debug.Log("LEFT PADDLE GROW DEACTIVATED");
            StartCoroutine(GrowPaddleCooldown());
        }
    }

    IEnumerator GrowPaddleCooldown()
    {
        yield return new WaitForSeconds(paddleGrowCooldownTime);
        deactivatePaddleGrow = false;
        Debug.Log("LEFT PADDLE GROW READY");
    }

    private void ActivatePaddleAccelerate()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(paddleAccelerateKey) && deactivatePaddleAccelerate == false)
            {
                acceleratePaddleScript.activateLeftPaddleAccelerate = true;
                deactivatePaddleAccelerate = true;
                Debug.Log("RIGHT PADDLE ACCELERATE ACTIVATED");
                powerupActive = true;
            }
        }

        if (acceleratePaddleScript.usedLeftPaddleAccelerate == true)
        {
            acceleratePaddleScript.usedLeftPaddleAccelerate = false;
            Debug.Log("RIGHT PADDLE ACCELERATE DEACTIVATED");
            powerupActive = false;
            StartCoroutine(AcceleratePaddleCooldown());
        }
    }

    IEnumerator AcceleratePaddleCooldown()
    {
        yield return new WaitForSeconds(paddleAccelerateCooldownTime);
        deactivatePaddleAccelerate = false;
        Debug.Log("RIGHT PADDLE ACCELERATE READY");
    }
}
