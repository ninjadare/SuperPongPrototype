using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerScore : MonoBehaviour
{
    [SerializeField] private GameObject arenaScript;
    [SerializeField] private GameObject ball;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == ball)
        {
            arenaScript.GetComponent<GameManager>().UpdateLeftPlayerScore();
        }
    }
}
