using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCollide : MonoBehaviour
{
    public GameObject _canvas;
    public GameObject UICamera;
    
    
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
        UICamera.SetActive(true);
        _canvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        gameObject.SetActive(false);
        /*GameObject[] bmanlist = GameObject.FindGameObjectsWithTag("BusinessMan");
        foreach (var man in bmanlist)
        {
            man.SetActive(false);
        }*/
    }
}
