using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionActivate : MonoBehaviour
{
    public GameObject UICamera;
    public GameObject player;
    public GameObject endgameCanvas;

    public GameObject gameManager;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UICamera.SetActive(true);
            player.SetActive(false);
            endgameCanvas.SetActive(true);
            gameManager.SetActive(false);
        }
    }
}
