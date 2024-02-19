using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BusinessActions : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public GameObject _player;
    public FieldOfView _fov;

    private float transY;
    void Start()
    {
        transY = transform.position.y;
    }
    void Update()
    {
        if (_fov.canSeePlayer)
        {
            Chase();
            Debug.Log("I can see you");
        }
    }

    public void Walk()
    {
        
    }

    public void Chase()
    {
        transform.LookAt(_player.transform);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transY, transform.position.z);
    }
}
