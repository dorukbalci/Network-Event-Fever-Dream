using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WalkAround : MonoBehaviour
{
    public float maxDist = 10f;
    public float changeTarget = 10f;
    public float moveSpeed = 2.0f;
    
    private float targetTimer = 0f;
    private Vector3 walkTarget;

    private void Start()
    {
        SetNewTarget();
    }

    // Update is called once per frame
    private void Update()
    {
        targetTimer += Time.deltaTime;
        if (targetTimer > changeTarget)
        {
            SetNewTarget();
            targetTimer = 0f;
        }
    }

    public void SetNewTarget()
    {
        walkTarget = new Vector3(transform.position.x + Random.Range(-maxDist, maxDist), transform.position.y,
            transform.position.z + Random.Range(-maxDist, maxDist));
    }

    public void WalkTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, walkTarget, moveSpeed * Time.deltaTime);
    }
}
