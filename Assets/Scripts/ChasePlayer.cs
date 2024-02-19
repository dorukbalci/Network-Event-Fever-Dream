using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public float chaseSpeed = 2.0f;
    public GameObject _player;
    public FieldOfView _fov;
    
    private float transY;
    void Start()
    {
        transY = transform.position.y;
    }

    public void Chase()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, chaseSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transY, transform.position.z);
    }
}
