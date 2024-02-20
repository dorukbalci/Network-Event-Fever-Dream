using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCollide : MonoBehaviour
{
    public GameObject _canvas;
    public Camera UICamera;
    public Camera playerCamera;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BusinessMan"))
        {
            InitiateDialogue();
            Destroy(other.gameObject);
        }
    }

    private void InitiateDialogue()
    {
        Time.timeScale = 0;
        UICamera.enabled = true;
        _canvas.SetActive(true);
        playerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        /*GameObject[] bmanlist = GameObject.FindGameObjectsWithTag("BusinessMan");
        foreach (var man in bmanlist)
        {
            man.SetActive(false);
        }*/
    }
}
