using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private KeyCode curveBallKey;
    [SerializeField] private float curveBallCooldownTime;
    [SerializeField] CurveBall curveBallScript;

    private bool deactivateCurveBall;

    private void Update()
    {
        ActivateCurveBall();
    }

    public void ActivateCurveBall()
    {
        if (Input.GetKeyDown(curveBallKey) && deactivateCurveBall == false)
        {
            curveBallScript.activateCurveBall = true;
            deactivateCurveBall = true;
            Debug.Log("curve ball powerup ACTIVATED");
        }

        if (curveBallScript.usedCurveBall == true)
        {
            curveBallScript.usedCurveBall = false;
            curveBallScript.activateCurveBall = false;
            Debug.Log("curve ball powerup DEACTIVATED");
            StartCoroutine(CurveBallCooldown());
        }
    }

    IEnumerator CurveBallCooldown()
    {
        yield return new WaitForSeconds(curveBallCooldownTime);
        deactivateCurveBall = false;
        Debug.Log("curve ball powerup READY");
    }
}
