using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionActivate : MonoBehaviour
{
    public GameObject UICamera;
    public GameObject player;
    public GameObject endgameCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UICamera.SetActive(true);
            player.SetActive(false);
            endgameCanvas.SetActive(true);
        }
    }
}
