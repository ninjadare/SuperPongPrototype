using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScore : MonoBehaviour
{
    public GameObject arenaScript;

    private void OnTriggerEnter(Collider ball)
    {
        arenaScript.GetComponent<GameManager>().UpdateRightScore();
    }
}
