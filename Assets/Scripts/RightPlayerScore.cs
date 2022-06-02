using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayerScore : MonoBehaviour
{
    [SerializeField] private GameObject arenaScript;
    [SerializeField] private GameObject ball;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == ball)
        {
            arenaScript.GetComponent<GameManager>().UpdateRightPlayerScore();
        }
    }
}
