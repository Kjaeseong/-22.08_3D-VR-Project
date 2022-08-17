using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    private DetectionTarget _detection;
    private ZombieStatus _zombie;

    public bool IsRunning;
    private float _moveSpeed;
    private bool _canTurn;
    public float TurnDelay = 4f;
    private float _turn = 0f;
    public bool LockOn;

    private void Awake()
    {
        _detection = GetComponent<DetectionTarget>();
        _zombie = GetComponent<ZombieStatus>();
    }

    private void Update()
    {
        if (_detection.TargetTransform != null)
        {
            LockOn = true;
            RunToTarget();
        }
        else
        {
            LockOn = false;
            IdleMove();
        }
    }

    void RunToTarget()
    {
        _moveSpeed = _zombie.RunSpeed;
        IsRunning = true;
        float DistanceToTarget = Vector3.Distance(transform.position, _detection.TargetTransform.position);
        transform.LookAt(_detection.TargetTransform);

        if (DistanceToTarget >= 1.5f)
        { 
            transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward.normalized);
        }
    }

    void IdleMove()
    {
        _moveSpeed = _zombie.WalkSpeed;
        IsRunning = false;

        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward.normalized);
        Turn();
    }

    void Turn()
    {
        _turn += Time.deltaTime;
        if (_turn >= TurnDelay)
        {
            Debug.Log("방향전환");

            transform.rotation = Quaternion.Euler(0f, Random.Range(0, 180), 0f); 


            







            _turn = 0f;
        }
        
    }

}
