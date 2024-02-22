using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject UIcamera;
    public GameObject dialogueCanvas;
    public GameObject posCanvas;
    
    public Image playerTimer;
    public Image dialogueTimer;

    public float maxTime = 5f;
    float timeLeft;
    public GameObject loseGameCanvas;

    private void Start()
    {
        timeLeft = maxTime;
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            playerTimer.fillAmount = timeLeft / maxTime;
            dialogueTimer.fillAmount = timeLeft / maxTime;
        }
        else
        {
            player.SetActive(false);
            UIcamera.SetActive(true);
            loseGameCanvas.SetActive(true);
            dialogueCanvas.SetActive(false);
            posCanvas.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
