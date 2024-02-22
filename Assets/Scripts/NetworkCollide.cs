using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkCollide : MonoBehaviour
{
    public GameObject _canvas;
    public GameObject UICamera;
    public Image canvasImage;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BusinessMan"))
        {
            var spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
            canvasImage.sprite = spriteRenderer.sprite;
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
        
    }
}
