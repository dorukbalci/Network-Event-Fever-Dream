using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessManager : MonoBehaviour
{
    public GameObject _player;
    
    private FieldOfView fieldOfView;
    private ChasePlayer chasePlayer;
    private WalkAround walkAround;
    
    [SerializeField] private float rotSpeed = 60f;
    [SerializeField] private int rotAmount = 30;
    [SerializeField] private int rotOffset = 20;
    
    void Start()
    {
        fieldOfView = GetComponent<FieldOfView>();
        chasePlayer = GetComponent<ChasePlayer>();
        walkAround = GetComponent<WalkAround>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform);
        if (fieldOfView.isChasing)
        {
            chasePlayer.Chase();
            walkAnim();
        }
        else
        {
            walkAround.WalkTowardsTarget();
        }
    }

    void walkAnim()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y , Mathf.PingPong(Time.time * rotSpeed, rotAmount)-rotOffset);
    }
}
