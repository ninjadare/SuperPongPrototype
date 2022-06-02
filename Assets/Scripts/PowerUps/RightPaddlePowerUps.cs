using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddlePowerUps : MonoBehaviour
{
    [Header("Fast Ball Power-Up")]
    [SerializeField] private KeyCode fastBallKey;
    [SerializeField] private float fastBallCooldownTime;
    [SerializeField] private RightPaddleFastBall fastBallScript;
    [SerializeField] private Material fastBallMaterial;

    [Header("Curve Ball Power-Up")]
    [SerializeField] private KeyCode curveBallKey;
    [SerializeField] private float curveBallCooldownTime;
    [SerializeField] private RightPaddleCurveBall curveBallScript;
    [SerializeField] private Material curveBallMaterial;

    [Header("Paddle Grow Power-Up")]
    [SerializeField] private KeyCode paddleGrowKey;
    [SerializeField] private float paddleGrowCooldownTime;
    [SerializeField] private RightPaddleGrow growPaddleScript;
    [SerializeField] private Material paddleGrowMaterial;

    [Header("Paddle Accelerate Power-Up")]
    [SerializeField] private KeyCode paddleAccelerateKey;
    [SerializeField] private float paddleAccelerateCooldownTime;
    [SerializeField] private RightPaddleAccelerate acceleratePaddleScript;
    [SerializeField] private Material paddleAccelerateMaterial;

    private bool powerupActive = false;
    private bool deactivateFastBall;
    private bool deactivateCurveBall;
    private bool deactivatePaddleGrow;
    private bool deactivatePaddleAccelerate;

    private MeshRenderer meshRenderer;
    private Material oldMaterial;

    private void Start()
    {
        // Get the Mesh Renderer Component from this gameObject
        meshRenderer = GetComponentInParent<MeshRenderer>();

        // Get the current material applied on this GameObject
        oldMaterial = meshRenderer.material;
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
                fastBallScript.activateRightFastBall = true;
                deactivateFastBall = true;
                Debug.Log("RIGHT PADDLE FAST BALL ACTIVATED");
                meshRenderer.material = fastBallMaterial;
                powerupActive = true;
            }
        }

        if (fastBallScript.usedRightFastBall == true)
        {
            fastBallScript.usedRightFastBall = false;
            fastBallScript.activateRightFastBall = false;
            Debug.Log("RIGHT PADDLE FAST BALL DEACTIVATED");
            meshRenderer.material = oldMaterial;
            powerupActive = false;
            StartCoroutine(FastBallCooldown());
        }
    }

    IEnumerator FastBallCooldown()
    {
        yield return new WaitForSeconds(fastBallCooldownTime);
        deactivateFastBall = false;
        Debug.Log("RIGHT PADDLE FAST BALL READY");
    }

    private void ActivateCurveBall()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(curveBallKey) && deactivateCurveBall == false)
            {
                curveBallScript.activateRightCurveBall = true;
                deactivateCurveBall = true;
                Debug.Log("RIGHT PADDLE CURVE BALL ACTIVATED");
                meshRenderer.material = curveBallMaterial;
                powerupActive = true;
            }
        }

        if (curveBallScript.usedRightCurveBall == true)
        {
            curveBallScript.usedRightCurveBall = false;
            curveBallScript.activateRightCurveBall = false;
            Debug.Log("RIGHT PADDLE CURVE BALL DEACTIVATED");
            meshRenderer.material = oldMaterial;
            powerupActive = false;
            StartCoroutine(CurveBallCooldown());
        }
    }

    IEnumerator CurveBallCooldown()
    {
        yield return new WaitForSeconds(curveBallCooldownTime);
        deactivateCurveBall = false;
        Debug.Log("RIGHT PADDLE CURVE BALL READY");
    }

    private void ActivatePaddleGrow()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(paddleGrowKey) && deactivatePaddleGrow == false)
            {
                growPaddleScript.activateRightPaddleGrow = true;
                deactivatePaddleGrow = true;
                Debug.Log("RIGHT PADDLE GROW ACTIVATED");
                meshRenderer.material = paddleGrowMaterial;
                powerupActive = true;
            }
        }

        if (growPaddleScript.usedRightPaddleGrow == true)
        {
            growPaddleScript.usedRightPaddleGrow = false;
            Debug.Log("RIGHT PADDLE GROW DEACTIVATED");
            meshRenderer.material = oldMaterial;
            powerupActive = false;
            StartCoroutine(GrowPaddleCooldown());
        }
    }

    IEnumerator GrowPaddleCooldown()
    {
        yield return new WaitForSeconds(paddleGrowCooldownTime);
        deactivatePaddleGrow = false;
        Debug.Log("RIGHT PADDLE GROW READY");
    }

    private void ActivatePaddleAccelerate()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(paddleAccelerateKey) && deactivatePaddleAccelerate == false)
            {
                acceleratePaddleScript.activateRightPaddleAccelerate = true;
                deactivatePaddleAccelerate = true;
                Debug.Log("RIGHT PADDLE ACCELERATE ACTIVATED");
                meshRenderer.material = paddleAccelerateMaterial;
                powerupActive = true;
            }
        }

        if (acceleratePaddleScript.usedRightPaddleAccelerate == true)
        {
            acceleratePaddleScript.usedRightPaddleAccelerate = false;
            Debug.Log("RIGHT PADDLE ACCELERATE DEACTIVATED");
            meshRenderer.material = oldMaterial;
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
