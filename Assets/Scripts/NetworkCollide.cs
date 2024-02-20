using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCollide : MonoBehaviour
{
    public GameObject _canvas;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BusinessMan"))
        {
            Destroy(other.gameObject);
            _canvas.SetActive(true);
            PauseBusinessMan();
        }
            
            
    }

    private void PauseBusinessMan()
    {
        //Time.timeScale = 0;
        GameObject[] bmanlist = GameObject.FindGameObjectsWithTag("BusinessMan");
        foreach (var man in bmanlist)
        {
            man.SetActive(false);
        }
    }
}
