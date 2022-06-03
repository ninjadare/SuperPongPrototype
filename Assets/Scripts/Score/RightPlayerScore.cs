using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Darius
public class RightPlayerScore : MonoBehaviour
{
    [SerializeField] private GameObject gameManagerScript;
    [SerializeField] private GameObject ball;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == ball)
        {
            gameManagerScript.GetComponent<GameManager>().UpdateRightPlayerScore();
        }
    }
}
